using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;
    [SerializeField] GameObject selectedUnit;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.PlayerTurn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.PlayerTurn:
                break;
            case GameState.MoveUnit:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    PlayerTurn = 0,
    MoveUnit = 1,
    EnemiesTurn = 2
}