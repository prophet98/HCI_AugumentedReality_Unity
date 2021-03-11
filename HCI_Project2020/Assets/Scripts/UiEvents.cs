
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

    private void OnCloseDistance()
    {
        doubleDiceText.text = "NICE! NOW GO BACK TO THE DICE AND CHECK HOW MANY SHOTS YOU HAVE TO TAKE!";
        doubleDiceText.gameObject.SetActive(true);
        GameController.Instance.gameState = GameController.GameState.ThrowSingleDice;
        DiceThrowScript.NormalThrow = true;
    }

    private void OnDoubleDiceResult()
    {
        if (DiceThrowScript.NormalThrow == false)
        {
            doubleDiceText.text = "NOW LOOK AT THE TWO MARKERS AND COMBINE THEM TOGETHER";
            doubleDiceText.gameObject.SetActive(true);
            GameController.Instance.gameState = GameController.GameState.WaitForDiceResult;
        }
    }
    
    void OnDisable()
    {
        DiceValue.onDiceResult -= OnDoubleDiceResult;
        CheckObjDistance.onCloseObj -= OnCloseDistance;
    }
}
