
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance => _instance;

    public enum GameState
    {
        Default,
        ThrowDices,
        ThrowSingleDice,
        WaitForDiceResult
    }

    public GameState gameState = GameState.Default;
    
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
    }
}
