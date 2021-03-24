
using System;
using UnityEngine;

public class CheckObjDistance : MonoBehaviour
{
    public Transform other;

    public delegate void DistanceAction();
    public static event DistanceAction onCloseObj;
    private void Start()
    {
        InvokeRepeating(nameof(CheckDistance),.5f,.5f);
    }

    public void CheckDistance()
    {
        if (other.GetComponentInChildren<MeshRenderer>() == null || other.GetComponentInChildren<MeshRenderer>().enabled == false ) return;
        var dist = Vector3.Distance(other.position, transform.position);
        var formattedDistance = Convert.ToDouble(String.Format("{0:0.00}", dist));
        
        if (dist <= 0.1f)
        {
            onCloseObj?.Invoke();
            CancelInvoke();
        }
        print($"Distance to other: {formattedDistance}");
    }
}
