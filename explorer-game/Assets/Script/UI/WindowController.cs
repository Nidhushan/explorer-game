using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WindowController : MonoBehaviour
{
    public static WindowController activeInstance;
    public bool IsShown { get; private set; }
    public string windowID;

    public bool Show()
    {
        if (activeInstance == this)
        {
            return true;
        }

        activeInstance?.Hide();
        GetComponent<Animator>().SetBool("show", true);
        activeInstance = this;
        IsShown = true;
        return true;
    }

    public void Hide()
    {
        GetComponent<Animator>().SetBool("show", false);
        IsShown = false;
    }
}