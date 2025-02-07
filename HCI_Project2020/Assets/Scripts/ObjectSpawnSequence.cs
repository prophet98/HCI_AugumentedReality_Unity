﻿using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Vuforia;

public class ObjectSpawnSequence : MonoBehaviour
{
    private Vector3 _startingScale;
    private Vector3 _endingScale;
    private Transform _objTransform;
    private Tween _mySpawnTween = null;
    private MeshRenderer _meshRenderer;

    private void OnEnable()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void Awake()
    {
        _objTransform = transform;
        _endingScale = _objTransform.localScale;
        _startingScale = Vector3.zero;
    }

    public void OnTrackFoundAnimation()
    {
        if (CheckGameState())
        {
            _objTransform.localScale = _startingScale;
            _mySpawnTween = transform.DOScale(_endingScale, 3f);  
        }
    }
    public void OnTrackLostAnimation()
    {
        if (CheckGameState())
        {
            _objTransform.localScale = _startingScale; 
            _mySpawnTween.Rewind();
        }
    }
    private bool CheckGameState()
    {
        if (GameController.Instance.gameState == GameController.GameState.WaitForDiceResult)
        {
            return true;
        }
        if (GameController.Instance.gameState != GameController.GameState.WaitForDiceResult)
        {
            return false;
        }
        
        return true;
    }
}
