using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Script : MonoBehaviour
{
    public Player_Movement pMoveScript;
    public GameObject canvasEnd;

    //Stops race on trigger, then shows menu
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit");
        if (collider.tag == "Player")
        {
            pMoveScript.HitObstacle();
            canvasEnd.SetActive(true);
            Timer_Script.timer.Stop();
            Debug.Log("Hit Player");
        }
    }
}
