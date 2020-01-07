using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Script : MonoBehaviour
{
    public Player_Movement pMoveScript;

    [SerializeField]
    private float fastTime;
    [SerializeField]
    private float medTime;
    [SerializeField]
    private float slowTime;

    public GameObject Flag1;
    public GameObject Flag2;

    public GameObject canvasEnd;

    private AudioSource speaker;

    //Starts the second flag animation slightly late so they look less alike when the player comes to the finish
    public void Start()
    {
        Invoke("SpawnFlag", 1.0f);
        speaker = this.GetComponent<AudioSource>();
    }

    //Stops race on trigger, then calculates player time
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            pMoveScript.StopRacing();
            canvasEnd.SetActive(true);
            CalculateStars();
            Timer_Script.timer.Stop();
            speaker.Play();
            canvasEnd.GetComponentInChildren<Return_To_World_Script>().noWin = false;
            canvasEnd.GetComponent<Finish_Menu_Script>().CountStars(World_Script.starsAchieved);
        }
    }

    //Spawns the flag
    public void SpawnFlag()
    {
        Flag2.SetActive(true);
    }

    //Calculates the number of stars awarded according to player time
    public void CalculateStars()
    {
        if (fastTime >= Timer_Script.timer.Elapsed.TotalSeconds)
        {
            World_Script.starsAchieved = 3;
        }
        else if (medTime >= Timer_Script.timer.Elapsed.TotalSeconds)
        {
            World_Script.starsAchieved = 2;
        }
        else if (slowTime >= Timer_Script.timer.Elapsed.TotalSeconds)
        {
            World_Script.starsAchieved = 1;
        }
        else
        {
            World_Script.starsAchieved = 0;
        }
    }
}
