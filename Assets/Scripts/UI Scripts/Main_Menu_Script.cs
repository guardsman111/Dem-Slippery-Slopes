using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Script : MonoBehaviour
{
    public GameObject UI2;
    public GameObject mainCamera;
    public GameObject player;

    //Starts the world screen
    public void Play()
    {
        UI2.SetActive(true);
        mainCamera.GetComponent<World_Camera_Script>().enabled = true;
        player.SetActive(true);
        this.gameObject.SetActive(false);
    }

    //Quits the application
    public void Quit()
    {
        Application.Quit();
    }
}
