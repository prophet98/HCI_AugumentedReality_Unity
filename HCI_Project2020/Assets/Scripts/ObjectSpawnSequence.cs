using System;
using DG.Tweening;
using UnityEngine;


public class ObjectSpawnSequence : MonoBehaviour
{
    private Vector3 _startingScale;
    private Vector3 _endingScale;
    private Transform _objTransform;
    private Tween _mySpawnTween;

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
            _objTransform.gameObject.SetActive(true);
            _objTransform.localScale = _startingScale;
            _mySpawnTween = transform.DOScale(_endingScale, 2.5f);
            var spawnedObj = _objTransform.GetComponentInChildren<Transform>(true).gameObject;
            spawnedObj.SetActive(true);
            SoundManager.instance?.Play(Sound.Names.SpawnObject);

        }
    }

    public void OnTrackLostAnimation()
    {
        if (CheckGameState())
        {
            _objTransform.gameObject.SetActive(false);
            _objTransform.localScale = _startingScale;
            var spawnedObj = _objTransform.GetComponentInChildren<Transform>(true).gameObject;
            spawnedObj.SetActive(false);
        }
    }

    private bool CheckGameState()
    {
        return GameController.Instance.gameState == GameController.GameState.WaitForDiceResult;
    }
}