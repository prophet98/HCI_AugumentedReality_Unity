﻿
using TMPro;
using UnityEngine;


public class UiEvents : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI doubleDiceText;
    private void OnEnable()
    {
        DiceValue.onDiceResult += OnDoubleDiceResult;
        CheckObjDistance.onCloseObj += OnCloseDistance;
    }

    void OnDisable()
    {
        DiceValue.onDiceResult -= OnDoubleDiceResult;
        CheckObjDistance.onCloseObj -= OnCloseDistance;
    }
    
    
    private void OnCloseDistance()
    {
        doubleDiceText.text = "NICE! NOW GO BACK TO THE DICE AND CHECK HOW MANY SHOTS YOU HAVE TO TAKE!";
        doubleDiceText.gameObject.SetActive(true);
        GameController.Instance.gameState = GameController.GameState.ThrowSingleDice;
        DiceThrowScript.normalThrow = true;
    }

    private void OnDoubleDiceResult()
    {
        if (DiceThrowScript.normalThrow == false && DiceThrowScript.DiceResults[0]!=0 && DiceThrowScript.DiceResults[1]!=0 )
        {
            doubleDiceText.text = "NOW LOOK AT THE TWO MARKERS AND COMBINE THEM TOGETHER";
            doubleDiceText.gameObject.SetActive(true);
            Debug.Log("Dices made the values " + DiceThrowScript.DiceResults[0] + " " + DiceThrowScript.DiceResults[1]);
            //TESTING SPAWN.
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.First, GameController.SpawnedObjPool.Boy);
            GameController.Instance.SpawnObjByIndex(GameController.Tracker.Second, GameController.SpawnedObjPool.Girl);
            GameController.Instance.gameState = GameController.GameState.WaitForDiceResult;
        }
    }
    
}
