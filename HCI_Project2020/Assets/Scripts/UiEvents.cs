using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UiEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject virtualButton;
    [SerializeField] private Sprite virtualButtonReturnSprite;

    private void OnEnable()
    {
        DiceValue.OnDiceResult += OnSingleDiceResult;
        DiceValue.OnDiceResult += OnDoubleDiceResult;
        CheckObjDistance.OnCloseObj += OnCloseDistance;
    }

    private void OnDisable()
    {
        DiceValue.OnDiceResult -= OnSingleDiceResult;
        DiceValue.OnDiceResult -= OnDoubleDiceResult;
        CheckObjDistance.OnCloseObj -= OnCloseDistance;
    }

    private void OnCloseDistance()
    {
        SetUiAndPunch("NICE! NOW GO BACK TO THE DICE AND CHECK HOW MANY SHOTS YOU HAVE TO TAKE!");
        GameController.Instance.gameState = GameController.GameState.ThrowSingleDice;
        DiceThrowScript.normalThrow = true;
    }

    private void OnDoubleDiceResult()
    {
        if (DiceThrowScript.normalThrow == false && DiceThrowScript.DiceResults[0] != 0 &&
            DiceThrowScript.DiceResults[1] != 0)
        {
            SetUiAndPunch("NOW LOOK AT THE TWO MARKERS AND COMBINE THEM TOGETHER");
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.First, DiceThrowScript.DiceResults[0]);
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.Second, DiceThrowScript.DiceResults[1]);
            GameController.Instance.gameState = GameController.GameState.WaitForDiceResult;
        }
    }

    private void OnSingleDiceResult()
    {
        if (DiceThrowScript.normalThrow && DiceThrowScript.DiceResults[2] != 0)
        {
            SetUiAndPunch($"YOU WILL HAVE TO DRINK {DiceThrowScript.DiceResults[2]} SHOTS!");
            GameController.Instance.gameState = GameController.GameState.NewTurn;
            virtualButton.GetComponentInChildren<SpriteRenderer>().sprite = virtualButtonReturnSprite;
        }
    }

    private void SetUiAndPunch(string text)
    {
        DOTween.KillAll();
        uiText.text = text;
        uiText.transform.DOPunchScale(new Vector3(2, 2, 2), .5f);
        uiText.gameObject.SetActive(true);
    }
}