using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameState currentState_READ_ONLY;

    // Start is called before the first frame update
    void Start()
    {
        currentState_READ_ONLY = GameStateManager.Instance.CurrentGameState;

        //ForceGamplayStateAtStart();
    }

    // Update is called once per frame
    //This is Pause Event Handler
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CheckAndChangeState();
            Debug.Log("Player click ESC");
        }
    }

    //Public method so I can access through buttons as well
    //Call upon this method will pause screen
    public void CheckAndChangeState()
    {
        //Grab the current game state
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        //Check value
        GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Pause
                : GameState.Gameplay;

        //Assign new State value
        GameStateManager.Instance.SetState(newGameState);

        currentState_READ_ONLY = newGameState;
    }

    //Due to weird Unity but that:Return To Menu -> Start game == State still in Pause
    //Forcing player to click ESC twice
    //Solution: Force start at beginning of all scene load
    /*private void ForceGamplayStateAtStart()
    {
        GameStateManager.Instance.SetState (GameState.Gameplay);
    }*/
}
