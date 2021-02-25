
using System.Collections.Generic;
using UnityEngine;

public class DiceThrowScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> dices3D;
    private List<GameObject> Dices3D => dices3D;
    private readonly List<Rigidbody> _rbList = new List<Rigidbody>();
    private bool _canThrow;
    private Vector3 _throwDirectionDice;
    
    public void Enabled() //Used by Vuforia
    {
        PosReset();
    }

    private void DiceThrow()
    {
        const float throwForceDice = 75f;

        for (int i = 0; i < Dices3D.Count; i++)
        {
            _throwDirectionDice = -GetComponentInParent<Transform>().forward;

            Dices3D[i].GetComponent<MeshRenderer>().enabled = true;
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = true;
            }
            _rbList[i].isKinematic = false;
            _rbList[i].useGravity = true;
            _rbList[i].AddForce(_throwDirectionDice * throwForceDice);
            _rbList[i].AddTorque(Random.Range(20f, 40f), Random.Range(20f, 40f), Random.Range(20f, 40f));
        }

        _canThrow = false;
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
        }

    }

    private void LateUpdate()
    {
        if (_canThrow)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DiceThrow();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            PosReset();
        }
    }

}
