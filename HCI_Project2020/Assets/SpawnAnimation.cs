using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnAnimation : MonoBehaviour
{ 
    public void SpawnAnimationEvent()
    {
        Debug.Log($"Spawn animation from {GetComponentInParent<Transform>().gameObject.name}");
    }

}
