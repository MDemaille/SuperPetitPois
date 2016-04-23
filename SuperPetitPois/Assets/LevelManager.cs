using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    //Timers
    private static float _backgroundSpeedTimer = 1;
    public static float BackgroundSpeedTimer;

    void Start()
    {
        ResetAllTimers();
    }

    public static void ResetAllTimers()
    {
        BackgroundSpeedTimer = _backgroundSpeedTimer;
    }

}
