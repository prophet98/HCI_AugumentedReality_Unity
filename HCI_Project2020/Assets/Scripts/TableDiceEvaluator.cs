
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
        Debug.Log("Check Dice Value");
        new WaitForSeconds(.2f);
        while (!diceThrowScript.DiceVelocities.Contains(Vector3.zero))
        {
            yield return null;
        }
        DiceThrowScript.areDicesStill = true;
    }


}
