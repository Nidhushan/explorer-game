using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static bool isTimePaused = false;


    public static void PauseTime()
    {
        isTimePaused = true;
    }

    public static void ResumeTime()
    {
        isTimePaused = false;
        Time.timeScale = 1; 
    }
}
