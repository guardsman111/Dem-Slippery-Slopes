using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route_Trigger_Script : MonoBehaviour
{
    public GameObject otherTrack;

    //Disables other routes the player isnt currently using in order to prevent track overlap or terrain overlaps
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            otherTrack.SetActive(false);
        }
    }
}
