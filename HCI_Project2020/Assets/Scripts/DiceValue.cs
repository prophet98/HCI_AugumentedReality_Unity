
using System;
using UnityEngine;

public class DiceValue : MonoBehaviour
{
    public delegate void DiceResult();
    public static event DiceResult onDiceResult;
    private void OnTriggerEnter(Collider other)
    {
        if (DiceThrowScript.AreDicesStill && other.name == "Table")
        {
            IntValueToDice(Convert.ToInt32(gameObject.name));
        }
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
        DiceThrowScript.DiceResults.Add(diceValue);
        onDiceResult?.Invoke();
    }

    
}
