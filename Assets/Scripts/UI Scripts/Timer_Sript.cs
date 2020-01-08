using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script : MonoBehaviour
{
    public static Stopwatch timer;
    private bool timerExists = false;
    private bool timerStopped = false;


    //Starts timer on race start and posts it to the UI
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !timerExists)
        {
            timer = new Stopwatch();
            timer.Start();
            timerExists = true;
        }

        if (timer != null)
        {
            TimeSpan elapsed = timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", elapsed.Minutes, elapsed.Seconds,
               elapsed.Milliseconds / 10);
            this.gameObject.GetComponent<Text>().text = elapsedTime;
        }

    }

}
