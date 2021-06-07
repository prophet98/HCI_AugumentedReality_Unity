using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private GameObject _firstTracker;
    private GameObject _secondTracker;
    [SerializeField] private GameObject[] zephyrActiveElements;
    [SerializeField] private GameObject[] zephyrPassiveElements;
    [SerializeField] private GameObject[] zephyrGlassesElements;
    [SerializeField] private Animation loadingAnimation;
    public static GameController Instance { get; private set; }

    private Transform _firstTrackerSpawnPos, _secondTrackerSpawnPos;

    public enum GameState
    {
        Default,
        ThrowDices,
        ThrowSingleDice,
        WaitForDiceResult,
        NewTurn
    }

    public GameState gameState = GameState.Default;


    public enum Tracker
    {
        First,
        Second
    }


    //Singleton game controller.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void TrackerSetup()
    {
        _firstTracker = GameObject.Find("FirstObjTarget").gameObject;
        _secondTracker = GameObject.Find("SecondObjTarget").gameObject;
        _firstTrackerSpawnPos = _firstTracker.GetComponentInChildren<Transform>();
        _secondTrackerSpawnPos = _secondTracker.GetComponentInChildren<Transform>();
    }

    private void Start()
    {
        TrackerSetup();
    }


    private IEnumerator ReloadScene()
    {
        loadingAnimation.Play("LoadingAnimation");
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        loadingAnimation.Play("LoadingAnimationExit");
        yield return new WaitForSeconds(.5f);
        gameState = GameState.Default;
        TrackerSetup();
    }

    public void ResetScene()
    {
        ResetStaticVars();
        StartCoroutine(ReloadScene());
    }

    private static void ResetStaticVars()
    {
        for (int i = 0; i < DiceThrowScript.DiceResults.Length; i++)
        {
            DiceThrowScript.DiceResults[i] = 0;
        }

        DiceThrowScript.normalThrow = false;
        DiceThrowScript.areDicesStill = false;
    }

    public void SpawnObjByIndex(Tracker trackerIndex, int result)
    {
        GameObject obj;
        switch (trackerIndex)
        {
            case Tracker.First:
                switch (result)
                {
                    case 1:
                        obj = Instantiate(zephyrActiveElements[Random.Range(0, zephyrActiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                    case 2:
                        obj = Instantiate(zephyrActiveElements[Random.Range(0, zephyrActiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                    case 3:
                        obj = Instantiate(
                            zephyrPassiveElements[Random.Range(0, zephyrPassiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                    case 4:
                        obj = Instantiate(
                            zephyrPassiveElements[Random.Range(0, zephyrPassiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                    case 5:
                        obj = Instantiate(
                            zephyrPassiveElements[Random.Range(0, zephyrPassiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                    case 6:
                        obj = Instantiate(zephyrActiveElements[Random.Range(0, zephyrActiveElements.Length)].gameObject,
                            _firstTrackerSpawnPos.position, Quaternion.identity);
                        obj.transform.SetParent(_firstTrackerSpawnPos);
                        break;
                }

                break;
            case Tracker.Second:
                switch (result)
                {
                    case 1:
                        obj = Instantiate(zephyrGlassesElements[0].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                    case 2:
                        obj = Instantiate(zephyrGlassesElements[1].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                    case 3:
                        obj = Instantiate(zephyrGlassesElements[2].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                    case 4:
                        obj = Instantiate(zephyrGlassesElements[3].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                    case 5:
                        obj = Instantiate(zephyrGlassesElements[4].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                    case 6:
                        obj = Instantiate(zephyrGlassesElements[5].gameObject, _secondTrackerSpawnPos.position,
                            Quaternion.identity);
                        obj.transform.SetParent(_secondTrackerSpawnPos);
                        break;
                }

                break;
        }
    }
}