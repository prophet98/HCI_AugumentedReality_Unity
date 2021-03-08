using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ObjectSpawnSequence : MonoBehaviour
{
    private Vector3 _startingScale;
    private Vector3 _endingScale;
    private Transform _objTransform;
    private Tween _mySpawnTween = null;
    private void Start()
    {
        Debug.Log("Start");
        _objTransform = transform;
        _endingScale = _objTransform.localScale;
        _startingScale = Vector3.zero;
    }

    public void OnTrackFoundAnimation()
    {
        _objTransform.localScale = _startingScale;
        
        _mySpawnTween = transform.DOScale(_endingScale, 3f);
    }

    public void OnTrackLostAnimation()
    {
        if (_objTransform != null) 
        {
            _mySpawnTween.Rewind();
            transform.localScale = _startingScale;
            _objTransform.localScale = _startingScale;  
        }

    }
}
