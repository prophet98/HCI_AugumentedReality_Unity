using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrowScript : MonoBehaviour
{
    [SerializeField] List<GameObject> dices3D;
    public List<GameObject> Dices3D { get => dices3D; set => dices3D = value; }
    readonly List<Rigidbody> rbList = new List<Rigidbody>();
    Vector3 throwDirectionDice;
    // Start is called before the first frame update
    void Start()
    {
        PosReset();
    }

    private void DiceThrow()
    {
        float throwForceDice = 50f;

        for (int i = 0; i < Dices3D.Count; i++)
        {
            throwDirectionDice = -GetComponent<Transform>().up;

            Dices3D[i].GetComponent<MeshRenderer>().enabled = true;
            rbList[i].isKinematic = false;
            rbList[i].useGravity = true;
            rbList[i].AddForce(throwDirectionDice * throwForceDice);
            rbList[i].AddTorque(Random.Range(100f, 400f), Random.Range(100f, 400f), Random.Range(100f, 400f));
        }
        
    }
    public void PosReset()
    {
        //yield return new WaitForSeconds(4f);
        Dices3D[0].transform.localPosition = new Vector3(-.2f, 0, 0);
        Dices3D[1].transform.localPosition = new Vector3(0, 0, 0);
        Dices3D[2].transform.localPosition = new Vector3(.2f, 0, 0);
        for (int i = 0; i < Dices3D.Count; i++)
        {
            rbList.Add(Dices3D[i].GetComponent<Rigidbody>());
            rbList[i].isKinematic = true;
            rbList[i].useGravity = false;
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            Dices3D[i].transform.rotation = Quaternion.identity;
            Dices3D[i].transform.localRotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        }

    }

    // Update is called once per frame
    void Update()
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
