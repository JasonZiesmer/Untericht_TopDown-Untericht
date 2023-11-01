using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameState.SetState(GameState.State.InGame);
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
