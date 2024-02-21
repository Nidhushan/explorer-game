using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WindowController : MonoBehaviour
{
    public static Dictionary<string, WindowController> windows = new();
    public static WindowController activeInstance;
    public bool IsShown { get; private set; }
    public string windowID;

    protected Animator animator;

    public bool Show()
    {
        if (activeInstance == this)
        {
            return true;
        }

        activeInstance?.Hide();
        animator.SetBool("show", true);
        activeInstance = this;
        IsShown = true;
        gameObject.SetActive(true);
        return true;
    }

    public void Hide()
    {
        animator.SetBool("show", false);
        IsShown = false;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        windows[windowID] = this;
        animator = GetComponent<Animator>();
        Hide();
    }
}