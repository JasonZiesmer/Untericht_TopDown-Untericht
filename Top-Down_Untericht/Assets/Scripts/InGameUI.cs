using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        GameState.onStageChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameState.onStageChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState.State newState)
    {
        gameOverScreen.SetActive(newState == GameState.State.GameOver);
    }

    public void RestartLevel1()
    {
        GameState.SetState(GameState.State.InGame);
    }

    public void ToMainMenu()
    {
        GameState.SetState(GameState.State.MainMenu);
    }
}
