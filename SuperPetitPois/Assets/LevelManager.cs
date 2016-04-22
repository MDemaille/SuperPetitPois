using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    //Timers
    private static int _backgroundSpeedTimer = 1;
    public static int BackgroundSpeedTimer;

    void Start()
    {
        ResetAllTimers();
    }

    public static void ResetAllTimers()
    {
        BackgroundSpeedTimer = _backgroundSpeedTimer;
    }

}
