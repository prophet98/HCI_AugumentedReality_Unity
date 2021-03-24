
using System;
using System.Collections;
using UnityEngine;

public class TableDiceEvaluator : MonoBehaviour
{
    [SerializeField] private DiceThrowScript diceThrowScript;
    private void OnEnable()
    {
        DiceThrowScript.areDicesStill = false;
    }

    public IEnumerator CheckDiceValue()
    {
        yield return new WaitForSeconds(.2f);
        while (!CheckIfDiceAreMoving())
        {
            yield return null;
        }
        DiceThrowScript.areDicesStill = true;
    }

    private bool CheckIfDiceAreMoving()
    {
        foreach (var dice in diceThrowScript.DiceVelocities)
        {
            if (dice.magnitude>0)
            {
                return false;
            }
        }

        return true;
    }
}
