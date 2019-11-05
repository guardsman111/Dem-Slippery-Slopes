using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Script : MonoBehaviour
{
    public Player_Movement pMoveScript;

    [SerializeField]
    private float minTime;

    public GameObject Flag1;
    public GameObject Flag2;

    //Starts the second flag animation slightly late so they look less alike when the player comes to the finish
    public void Start()
    {
        Invoke("SpawnFlag", 1.0f);
    }

    //Stops race on trigger, then calculates player time
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            pMoveScript.StopRacing();
            if (minTime >= Timer_Sript.timer.Elapsed.TotalSeconds)
            {
                Debug.Log("Faster than minimum!"); // Minimum time completion script here
            }
            else
            {
                Debug.Log("Slower than minimum!"); // Other time completion scripts here and below
            }
        }
    }

    public void SpawnFlag()
    {
        Flag2.SetActive(true);
    }
}
