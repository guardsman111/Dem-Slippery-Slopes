using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Sript : MonoBehaviour
{
    public Stopwatch timer;
    private bool timerExists = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !timerExists)
        {
            timer = new Stopwatch();
            timer.Start();
            timerExists = true;
        }

        TimeSpan elapsed = timer.Elapsed;

        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", elapsed.Minutes, elapsed.Seconds,
           elapsed.Milliseconds / 10);
        this.gameObject.GetComponent<Text>().text = elapsedTime;
    }

}
