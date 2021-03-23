
using System;
using System.Collections;
using UnityEngine;

public class DiceValue : MonoBehaviour
{
    public delegate void DiceResult();

    private const string DiceName01 = "Dice01";
    private const string DiceName02 = "Dice02";
    
    public static event DiceResult onDiceResult;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CheckForStill());
    }

    private IEnumerator CheckForStill()
    {
        while (!DiceThrowScript.areDicesStill)
        {
            yield return null;
        }
        IntValueToDice(Convert.ToInt32(gameObject.name));
    }


    private void IntValueToDice(int diceColliderValue)
    {
        int diceValue = 0;
        switch (diceColliderValue)
        {
            case 1 :
                diceValue = 6;
                break;
            case 2:
                diceValue = 5;;
                break;
            case 3 :
                diceValue = 4;
                break;
            case 4:
                diceValue = 3;
                break;
            case 5 :
                diceValue = 2;
                break;
            case 6:
                diceValue = 1;
                break;
        }

        var parentObj = transform.parent.parent;
        Debug.Log($"The {parentObj.name} made the value: {diceValue}");
        
        if (parentObj.name == DiceName01)
        {
            DiceThrowScript.DiceResults[0] = diceValue;
        }
        else if (parentObj.name == DiceName02)
        {
            DiceThrowScript.DiceResults[1] = diceValue;
        }
        else
        {
            DiceThrowScript.DiceResults[2] = diceValue;
        }
        
        onDiceResult?.Invoke();
    }

    
}
