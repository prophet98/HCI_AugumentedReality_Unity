
using System.Collections;
using UnityEngine;

public class TableDiceEvaluator : MonoBehaviour
{
    [SerializeField] private DiceThrowScript diceThrowScript;
    private void OnEnable()
    {
        DiceThrowScript.AreDicesStill = false;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public IEnumerator CheckDiceValue()
    {
        new WaitForSeconds(.2f);
        while (!diceThrowScript.DiceVelocities.Contains(Vector3.zero))
        {
            yield return null;
        }
        DiceThrowScript.AreDicesStill = true;
    }


}
