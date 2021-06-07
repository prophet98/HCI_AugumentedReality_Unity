using System.Collections;
using System.Linq;
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
        return diceThrowScript.DiceVelocities.All(dice => !(dice.magnitude > 0));
    }
}