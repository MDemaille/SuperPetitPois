using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static GameObject Player;

    //Timers
    private static float _backgroundSpeedTimer = 1;
    public static float BackgroundSpeedTimer;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag(Tags.Player);
        ResetAllTimers();
    }

    public static void ResetAllTimers()
    {
        BackgroundSpeedTimer = _backgroundSpeedTimer;
    }

}
