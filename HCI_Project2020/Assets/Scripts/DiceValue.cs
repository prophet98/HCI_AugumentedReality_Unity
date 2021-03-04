
using System;
using UnityEngine;

public class DiceValue : MonoBehaviour
{
    private DiceThrowScript _diceThrowScript;
    
    private void Start()
    {
        _diceThrowScript = GetComponentInParent<DiceThrowScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (_diceThrowScript.areDicesStill && other.name == "Table")
        {
            IntValueToDice(Convert.ToInt32(gameObject.name));
        }
    }
    
    private int IntValueToDice(int diceColliderValue)
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

        Debug.Log($"The {this.transform.parent.parent.name} made the value: {diceValue}");
        return diceValue;
    }
}
