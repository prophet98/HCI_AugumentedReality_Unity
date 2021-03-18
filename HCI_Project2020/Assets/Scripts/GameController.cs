
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    [SerializeField] private GameObject firstTracker;
    [SerializeField] private GameObject secondTracker;
    [SerializeField] private GameObject[] go;
    public static GameController Instance => _instance;
    private Transform _firstTrackerSpawnPos, _secondTrackerSpawnPos;
    public enum GameState
    {
        Default,
        ThrowDices,
        ThrowSingleDice,
        WaitForDiceResult
    }

    public GameState gameState = GameState.Default;
    
    public enum SpawnedObjPool
    {
        Default,
        Glasses,
        Boy,
        Girl,
    }

    public SpawnedObjPool objectPool = SpawnedObjPool.Default;
    
    //Singleton game controller.
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else 
        {
            _instance = this;
        }
    }

    private void Start()
    {
        gameState = GameState.ThrowDices;
        _firstTrackerSpawnPos = firstTracker.GetComponentInChildren<Transform>();
        _secondTrackerSpawnPos = secondTracker.GetComponentInChildren<Transform>();
    }

    public void SpawnObjByIndex(int trackerIndex, SpawnedObjPool objectToSpawn)
    {
        GameObject obj;
        if (trackerIndex == 1)
        {
            switch (objectToSpawn)
            {
                case SpawnedObjPool.Default:
                    break;
                case SpawnedObjPool.Glasses:
                    break;
                case SpawnedObjPool.Boy:
                    obj = Instantiate(go[0].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    // obj.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case SpawnedObjPool.Girl:
                    obj = Instantiate(go[1].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    // obj.GetComponent<MeshRenderer>().enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectToSpawn), objectToSpawn, null);
            }
        }
        else
        {
            switch (objectToSpawn)
            {
                case SpawnedObjPool.Default:
                    break;
                case SpawnedObjPool.Glasses:
                    break;
                case SpawnedObjPool.Boy:
                    obj = Instantiate(go[0].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    // obj.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case SpawnedObjPool.Girl:
                    obj = Instantiate(go[1].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    // obj.GetComponent<MeshRenderer>().enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectToSpawn), objectToSpawn, null);
            }
        }

    }


}
