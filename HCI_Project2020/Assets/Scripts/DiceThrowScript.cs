
using System.Collections.Generic;
using UnityEngine;

public class DiceThrowScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> dices3D;
    private List<GameObject> Dices3D => dices3D;
    private readonly List<Rigidbody> _rbList = new List<Rigidbody>();

    private Vector3 _throwDirectionDice;
    
    public void Enabled() //Used by Vuforia
    {
        PosReset();
    }

    private void DiceThrow()
    {
        const float throwForceDice = 50f;

        for (int i = 0; i < Dices3D.Count; i++)
        {
            _throwDirectionDice = -GetComponent<Transform>().up;

            Dices3D[i].GetComponent<MeshRenderer>().enabled = true;
            _rbList[i].isKinematic = false;
            _rbList[i].useGravity = true;
            _rbList[i].AddForce(_throwDirectionDice * throwForceDice);
            //rbList[i].AddTorque(Random.Range(100f, 400f), Random.Range(100f, 400f), Random.Range(100f, 400f));
        }
    }

    private void PosReset()
    {
        //yield return new WaitForSeconds(4f);
        Dices3D[0].transform.localPosition = new Vector3(-10f, 0, 0);
        Dices3D[1].transform.localPosition = new Vector3(0, 0, 0);
        Dices3D[2].transform.localPosition = new Vector3(10f, 0, 0);
        for (int i = 0; i < Dices3D.Count; i++)
        {
            _rbList.Add(Dices3D[i].GetComponent<Rigidbody>());
            _rbList[i].isKinematic = true;
            _rbList[i].useGravity = false;
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            Dices3D[i].transform.rotation = Quaternion.identity;
            Dices3D[i].transform.localRotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DiceThrow();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            PosReset();
        }
    }

}
