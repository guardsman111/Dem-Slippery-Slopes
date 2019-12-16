using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Script : MonoBehaviour
{
    public Player_Movement pMoveScript;
    public GameObject canvasEnd;

    private AudioSource speaker;

    private void Start()
    {
        speaker = GetComponentInParent<AudioSource>();
    }

    //Stops race on trigger, then shows menu
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            pMoveScript.HitObstacle();
            canvasEnd.SetActive(true);
            Timer_Script.timer.Stop();
            speaker.Play();
            canvasEnd.GetComponentInChildren<Return_To_World_Script>().noWin = true;
        }
    }
}
