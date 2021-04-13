
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
using Random = UnityEngine.Random;

public class DiceThrowScript : MonoBehaviour
{
    private List<GameObject> Dices3D => dices3D;
    public List<Vector3> DiceVelocities { get; } = new List<Vector3>();

    private Vector3 _throwDirectionDice;

    [SerializeField] private TableDiceEvaluator tableDiceEvaluator;
    [SerializeField] private List<GameObject> dices3D;

    public static bool areDicesStill = false;
    public static bool normalThrow = false;
    private bool _canThrow;

    public static int[] DiceResults = {0, 0, 0};


    private void Start()
    {
        GetComponentInParent<DefaultTrackableEventHandler>().OnTargetLost.Invoke();
        GameController.Instance.gameState = GameController.GameState.ThrowDices;
    }

    private void SetUpDices()
    {
        dices3D.Clear();
        
        if (normalThrow)
        {
            dices3D.Add(GetComponentInChildren<BoxCollider>(true).gameObject);
        }
        else
        {
            for (int i = 1; i <=2 ; i++)
            {
                dices3D.Add(GetComponentsInChildren<BoxCollider>(true)[i].gameObject);
            }
        }
        foreach (var dice in Dices3D)
        {
            DiceVelocities.Add(dice.GetComponent<Rigidbody>().velocity);
            dice.gameObject.SetActive(false);
        }
        
        PosReset();
    }

    private void OnEnable()
    {
        SetUpDices();
    }

    private void OnDisable()
    {
        CancelInvoke();
        DiceVelocities.Clear();
        PosReset();
    }

    public void DiceThrow()
    {
        if (GameController.Instance.gameState == GameController.GameState.NewTurn)
        {
            GameController.Instance.ResetScene();
            return;
        }
        if (!_canThrow) return;
        if (GameController.Instance.gameState == GameController.GameState.WaitForDiceResult) return;
        if (DiceResults[2] != 0) return;
        areDicesStill = false;
        const float throwForceDice = 75f;
        _throwDirectionDice = transform.forward;
        
        foreach (var dice in dices3D)
        {
            Debug.Log("dice");
            dice.SetActive(true);
            var diceRb = dice.GetComponent<Rigidbody>();
            dice.GetComponent<MeshRenderer>().enabled = true;
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = true;
            }
            
            diceRb.isKinematic = false;
            diceRb.useGravity = true;
            diceRb.AddForce(_throwDirectionDice * throwForceDice);
            diceRb.AddTorque(Random.Range(200f, 400f), Random.Range(200f, 400f), Random.Range(200f, 400f));
        }

        _canThrow = false;
        StartCoroutine(tableDiceEvaluator.CheckDiceValue());
        InvokeRepeating(nameof(UpdateDiceVelocity), 0.2f, 0.2f);
    }
    
    private void UpdateDiceVelocity()
    {
        for (int i = 0; i < DiceVelocities.Count; i++)
        {
            DiceVelocities[i] = dices3D[i].GetComponent<Rigidbody>().velocity;
        }
    }
    
    private void PosReset()
    {
        _canThrow = true;

        for (int i = 0; i < Dices3D.Count; i++)
        {
            var diceRb = Dices3D[i].GetComponent<Rigidbody>();
            var currDice = dices3D[i];
            currDice.transform.localPosition = new Vector3(i*10f, 0, 0);
            diceRb.isKinematic = true;
            diceRb.useGravity = false;
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = false;
            }
            currDice.transform.rotation = Quaternion.identity;
            currDice.transform.localRotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            currDice.SetActive(false);
        }
    }
    
}
