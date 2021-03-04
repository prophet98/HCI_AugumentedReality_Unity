
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
        print($"Distance to other: {dist}");
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
