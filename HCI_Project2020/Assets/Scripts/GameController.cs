
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    [SerializeField] private GameObject firstTracker;
    [SerializeField] private GameObject secondTracker;
    [SerializeField] private GameObject[] zephyrElements;
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
    
    public enum Tracker
    {
        Default,
        First,
        Second
    }
    
    
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
        _firstTrackerSpawnPos = firstTracker.GetComponentInChildren<Transform>();
        _secondTrackerSpawnPos = secondTracker.GetComponentInChildren<Transform>();
    }

    public void SpawnObjByIndex(Tracker trackerIndex, SpawnedObjPool objectToSpawn)
    {
        GameObject obj;
        if (trackerIndex == Tracker.First)
        {
            switch (objectToSpawn)
            {
                case SpawnedObjPool.Default:
                    break;
                case SpawnedObjPool.Glasses:
                    break;
                case SpawnedObjPool.Boy:
                    obj = Instantiate(zephyrElements[1].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    // obj.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case SpawnedObjPool.Girl:
                    obj = Instantiate(zephyrElements[2].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectToSpawn), objectToSpawn, null);
            }
        }
        else if (trackerIndex == Tracker.Second)
        {
            switch (objectToSpawn)
            {
                case SpawnedObjPool.Default:
                    break;
                case SpawnedObjPool.Glasses:
                    break;
                case SpawnedObjPool.Boy:
                    obj = Instantiate(zephyrElements[1].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    break;
                case SpawnedObjPool.Girl:
                    obj = Instantiate(zephyrElements[2].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectToSpawn), objectToSpawn, null);
            }
        }

    }


}
