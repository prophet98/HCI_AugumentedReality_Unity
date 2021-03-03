
using System.Collections;
using UnityEngine;

public class TableDiceEvaluator : MonoBehaviour
{
    [SerializeField] DiceThrowScript diceThrowScript;
    private void OnEnable()
    {
        diceThrowScript.areDicesStill = false;
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
        diceThrowScript.areDicesStill = true;
    }


}
