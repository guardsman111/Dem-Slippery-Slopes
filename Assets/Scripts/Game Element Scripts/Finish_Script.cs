using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Script : MonoBehaviour
{
    [SerializeField]
    private Player_Movement pMoveScript;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            pMoveScript.StopRacing();
        }
    }
}
