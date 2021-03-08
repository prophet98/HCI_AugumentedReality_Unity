
using System;
using UnityEngine;

public class CheckObjDistance : MonoBehaviour
{
    public Transform other;

    private void OnEnable()
    {
        InvokeRepeating(nameof(CheckDistance),.5f,.5f);
    }

    public void CheckDistance()
    {
        if (other.GetComponent<MeshRenderer>().enabled == false) return;
        
        var dist = Vector3.Distance(other.position, transform.position);
        var totalCost = Convert.ToDouble(String.Format("{0:0.00}", dist));
        print($"Distance to other: {totalCost}");
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
