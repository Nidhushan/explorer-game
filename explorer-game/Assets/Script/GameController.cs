using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    InMenu, InGame, GameOver, Paused
}

public class GameController : MonoBehaviour
{
    public static GameState state = GameState.InMenu;
    public static GameController obj;

    public WindowController StartMenu;

    private void Start()
    {
        obj = this;
        switch (state)
        {
            case GameState.InMenu:
                StartMenu.gameObject.SetActive(true);
                StartMenu.Show();
                break;
            default:
                StartMenu.gameObject.SetActive(false);
                break;
        }
    }
}
