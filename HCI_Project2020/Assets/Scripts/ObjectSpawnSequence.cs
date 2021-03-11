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
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _objTransform = transform;
        _endingScale = _objTransform.localScale;
        _startingScale = Vector3.zero;
    }

    public void OnTrackFoundAnimation()
    {
        CheckGameState();
        _objTransform.localScale = _startingScale;
        _mySpawnTween = transform.DOScale(_endingScale, 3f);
    }

    private void CheckGameState()
    {
        if (GameController.Instance.gameState == GameController.GameState.ThrowDices)
        {
            _meshRenderer.enabled = false;
        }
        else if (GameController.Instance.gameState == GameController.GameState.ThrowSingleDice)
        {
            _meshRenderer.enabled = false;
        }
    
        else
        {
            _meshRenderer.enabled = true;
        }
    }

    public void OnTrackLostAnimation()
    {
        CheckGameState();
        if (_objTransform != null) 
        {
            _mySpawnTween.Rewind();
            transform.localScale = _startingScale;
            _objTransform.localScale = _startingScale;  
        }

    }
}
