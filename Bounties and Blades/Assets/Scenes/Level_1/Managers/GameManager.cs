using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.SpawnItems:
                UnitManager.Instance.SpawnItems();
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                UnitManager.Instance.EnemyTurn();
                break;
            // case GameState.GameWon:
            //     GameVictoryScreen.Setup();
            //     break;
            // case GameState.GameLost:
            //     GameOverScreen.Setup();
            //     break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4,
    SpawnItems = 5,
    GameWon = 6,
    GameLost = 7
}
