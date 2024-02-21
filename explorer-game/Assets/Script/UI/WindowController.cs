using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WindowController : MonoBehaviour
{
    public bool IsShown { get; private set; }
    public string windowID;

    public bool Show()
    {
        GetComponent<Animator>().SetBool("show", true);
        IsShown = true;
        return true;
    }

    public void Hide()
    {
        GetComponent<Animator>().SetBool("show", false);
        IsShown = false;
    }
}