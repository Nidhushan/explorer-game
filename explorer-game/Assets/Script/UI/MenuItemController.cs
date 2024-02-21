using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum MenuCallback
{
    Start, Resume, Restart, Pause
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
            case MenuCallback.Start:
                Debug.Log("UI trigger start");
                break;
            case MenuCallback.Resume:
                Debug.Log("UI trigger resume");
                break;
            case MenuCallback.Restart:
                Debug.Log("UI trigger restart");
                break;
            case MenuCallback.Pause:
                break;
        }
    }
}
