
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UiEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    private void OnEnable()
    {
        DiceValue.onDiceResult += OnSingleDiceResult;
        DiceValue.onDiceResult += OnDoubleDiceResult;
        CheckObjDistance.onCloseObj += OnCloseDistance;
    }

    

    private void OnDisable()
    {
        DiceValue.onDiceResult -= OnSingleDiceResult;
        DiceValue.onDiceResult -= OnDoubleDiceResult;
        CheckObjDistance.onCloseObj -= OnCloseDistance;
    }
    
    
    private void OnCloseDistance()
    {
        SetUiAndPunch("NICE! NOW GO BACK TO THE DICE AND CHECK HOW MANY SHOTS YOU HAVE TO TAKE!");
        GameController.Instance.gameState = GameController.GameState.ThrowSingleDice;
        DiceThrowScript.normalThrow = true;
    }
    

    private void OnDoubleDiceResult()
    {
        if (DiceThrowScript.normalThrow == false && DiceThrowScript.DiceResults[0]!=0 && DiceThrowScript.DiceResults[1]!=0 )
        {
            SetUiAndPunch("NOW LOOK AT THE TWO MARKERS AND COMBINE THEM TOGETHER");
            Debug.Log("Dices made the values " + DiceThrowScript.DiceResults[0] + " " + DiceThrowScript.DiceResults[1]);
            //TESTING SPAWN.
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.First, GameController.SpawnedObjPool.Glasses);
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.Second, GameController.SpawnedObjPool.Jewels);
            GameController.Instance.gameState = GameController.GameState.WaitForDiceResult;
        }
    }
    private void OnSingleDiceResult()
    {
        if (DiceThrowScript.normalThrow && DiceThrowScript.DiceResults[2]!=0)
        {
            SetUiAndPunch($"YOU WILL HAVE TO DRINK {DiceThrowScript.DiceResults[2]} SHOTS!");
            GameController.Instance.gameState = GameController.GameState.Default;
        }
    }
    
    private void SetUiAndPunch(string text)
    {
        uiText.text = text;
        uiText.transform.DOPunchScale(new Vector3(2, 2, 2), .5f);
        uiText.gameObject.SetActive(true);
    }
    
}
