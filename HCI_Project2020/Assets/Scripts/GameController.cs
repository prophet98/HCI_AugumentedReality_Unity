
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Jewels,
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

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                    obj = Instantiate(zephyrElements[0].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    break;
                case SpawnedObjPool.Boy:
                    
                    break;
                case SpawnedObjPool.Girl:
                    break;
                case SpawnedObjPool.Jewels:
                    obj = Instantiate(zephyrElements[3].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_firstTrackerSpawnPos);
                    break;
            }
        }
        else if (trackerIndex == Tracker.Second)
        {
            switch (objectToSpawn)
            {
                case SpawnedObjPool.Default:
                    break;
                case SpawnedObjPool.Glasses:
                    obj = Instantiate(zephyrElements[0].gameObject, _firstTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    break;
                case SpawnedObjPool.Boy:
                    
                    break;
                case SpawnedObjPool.Girl:
                    break;
                case SpawnedObjPool.Jewels:
                    obj = Instantiate(zephyrElements[3].gameObject, _secondTrackerSpawnPos.position, Quaternion.identity);
                    obj.transform.SetParent(_secondTrackerSpawnPos);
                    break;
            }
        }

    }


}
