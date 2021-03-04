
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceThrowScript : MonoBehaviour
{
    private List<GameObject> Dices3D => dices3D;
    private readonly List<Rigidbody> _rbList = new List<Rigidbody>();
    public List<Vector3> DiceVelocities { get; } = new List<Vector3>();

    private Vector3 _throwDirectionDice;
    
    private bool _canThrow;
    
    [SerializeField] private TableDiceEvaluator tableDiceEvaluator;
    [HideInInspector] public bool areDicesStill;
    [SerializeField] private List<GameObject> dices3D;

    public bool normalThrow;

    public void Enabled() //Used by Vuforia
    {
        foreach (var dice in GetComponentsInChildren<BoxCollider>())
        {
            dice.gameObject.SetActive(false);
        }
        dices3D.Clear();
        //add check for single or double dice
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
        }
        PosReset();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(UpdateDiceVelocity), 0.2f, 0.2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
        DiceVelocities.Clear();
        _rbList.Clear();
    }

    public void DiceThrow()
    {
        if (!_canThrow) return;
        const float throwForceDice = 75f;

        for (int i = 0; i < Dices3D.Count; i++)
        {
            _throwDirectionDice = GetComponentInParent<Transform>().forward;
            Dices3D[i].SetActive(true);
            Dices3D[i].GetComponent<MeshRenderer>().enabled = true;
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = true;
            }
            _rbList[i].isKinematic = false;
            _rbList[i].useGravity = true;
            _rbList[i].AddForce(_throwDirectionDice * throwForceDice);
            _rbList[i].AddTorque(Random.Range(200f, 400f), Random.Range(200f, 400f), Random.Range(200f, 400f));
        }

        StartCoroutine(tableDiceEvaluator.CheckDiceValue());
        
        _canThrow = false;
    }
    
    private void UpdateDiceVelocity()
    {
        for (int i = 0; i < DiceVelocities.Count; i++)
        {
            DiceVelocities[i] = _rbList[i].velocity;
        }
    }
    
    private void PosReset()
    {
        _canThrow = true;
        for (int i = 0; i < Dices3D.Count; i++)
        {
            Dices3D[i].transform.localPosition = new Vector3(i*10f, 0, 0);
            _rbList.Add(Dices3D[i].GetComponent<Rigidbody>());
            _rbList[i].isKinematic = true;
            _rbList[i].useGravity = false;
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = false;
            }
            Dices3D[i].transform.rotation = Quaternion.identity;
            Dices3D[i].transform.localRotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            dices3D[i].SetActive(false);
        }
    }


    
}
