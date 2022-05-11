using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameState;

public class GameStateManager
{
    private static GameStateManager instance;
    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)

                instance = new GameStateManager();

            return instance;

        }
    }

    public GameState CurrentGameState
    {
        get;
        private set;
    }

    public delegate void GameStateChangeHandler(GameState newGameState);

    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState (GameState newGameState)
    {
        //Check if state has changed
        if (newGameState == CurrentGameState)
        {
            return;
        }

        CurrentGameState = newGameState;
        OnGameStateChanged.Invoke(newGameState);
        
    }
}
