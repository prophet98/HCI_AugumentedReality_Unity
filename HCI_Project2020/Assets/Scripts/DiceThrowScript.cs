using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrowScript : MonoBehaviour
{
    [SerializeField] List<GameObject> dices3D;
    public List<GameObject> Dices3D { get => dices3D; set => dices3D = value; }
    readonly List<Rigidbody> rbList = new List<Rigidbody>();
    List<Vector3> throwForceDices = new List<Vector3>(3);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Dices3D.Count; i++)
        {
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            Dices3D[i].transform.localRotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            rbList.Add(Dices3D[i].GetComponent<Rigidbody>());
            rbList[i].useGravity = false;
        }

        
    }

    private void DiceThrow()
    {
        throwForceDices.Add(new Vector3(0, Random.Range(-300, -500), 0));
        throwForceDices.Add(new Vector3(0, Random.Range(-300, -500), 0));
        throwForceDices.Add(new Vector3(0, Random.Range(-300, -500), 0));

        for (int i = 0; i < Dices3D.Count; i++)
        {
            Dices3D[i].GetComponent<MeshRenderer>().enabled = true;
            rbList[i].useGravity = true;
            rbList[i].isKinematic = false;
            rbList[i].AddForce(throwForceDices[Random.Range(0, throwForceDices.Count)]);
            rbList[i].AddTorque(Random.Range(100, 400), Random.Range(100, 400), Random.Range(100, 400));
        }
        throwForceDices.Clear();
    }
    public void PosReset()
    {
        //yield return new WaitForSeconds(4f);
        Dices3D[0].transform.localPosition = new Vector3(-1.5f, 0, 0);
        Dices3D[1].transform.localPosition = new Vector3(0, 0, 0);
        Dices3D[2].transform.localPosition = new Vector3(1.5f, 0, 0);
        for (int i = 0; i < Dices3D.Count; i++)
        {
            rbList[i].useGravity = false;
            rbList[i].isKinematic = true;
            Dices3D[i].GetComponent<MeshRenderer>().enabled = false;
            transform.rotation = Quaternion.identity;
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
