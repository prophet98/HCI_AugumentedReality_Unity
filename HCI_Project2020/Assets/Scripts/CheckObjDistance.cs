
using UnityEngine;

public class CheckObjDistance : MonoBehaviour
{
    public Transform other;
    public void SpawnAnimationEvent()
    {
        Debug.Log($"Spawn animation from {GetComponentInParent<Transform>().gameObject.name}");
    }

    private void Start()
    {
        InvokeRepeating(nameof(CheckDistance),.5f,.5f);
    }

    private void CheckDistance()
    {
        if (other.GetComponent<MeshRenderer>().enabled == false) return;
        var dist = Vector3.Distance(other.position, transform.position);
        print($"Distance to other: {dist}");
    }
}
