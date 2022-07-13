using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelBehaviour : MonoBehaviour
{
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    //Unsubscribe from event
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Pause);
    }

}
