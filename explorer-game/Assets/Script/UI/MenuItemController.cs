using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum MenuCallback
{
    Start, Resume, Restart, Pause, Level1, Level2, Menu
}

[Serializable]
public struct MenuItem
{
    public string Text;
    public MenuCallback Callback;
}

[RequireComponent(typeof(TextMeshProUGUI))]
public class MenuItemController : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private MenuItem data;

    public void Init(MenuItem item)
    {
        if (textMeshProUGUI != null)
        {
            Debug.LogError($"Repetitive initialization of {gameObject}");
            return;
        }
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        data = item;
        textMeshProUGUI.text = $"< > {data.Text}";
    }

    public void Select()
    {
        if (!textMeshProUGUI)
        {
            Debug.LogWarning("Uninitialized click!");
            return;
        }

        textMeshProUGUI.text = $"<x> {data.Text}";
    }

    public void Deselect()
    {
        if (!textMeshProUGUI)
        {
            Debug.LogWarning("Uninitialized click!");
            return;
        }

        textMeshProUGUI.text = $"< > {data.Text}";
    }
    public void Click()
    {
        if (!textMeshProUGUI)
        {
            Debug.LogWarning("Uninitialized click!");
            return;
        }

        switch (data.Callback)
        {
            // Main Menu
            case MenuCallback.Level1:
                GameController.state = GameState.InGame;
                SceneManager.LoadScene("Level1");
                break;
            case MenuCallback.Level2:
                GameController.state = GameState.InGame;
                SceneManager.LoadScene("Level2");
                break;
        }
    }
}
