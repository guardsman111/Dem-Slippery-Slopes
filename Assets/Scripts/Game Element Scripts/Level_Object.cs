using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Object : MonoBehaviour
{
    public string linkScene;
    public GameObject sledge;
    public GameObject play;
    public float moveSpeed = 0.3f;

    //Starts player sledge moving towards and rotates sledge to face this object
    public void OnMouseDown()
    {
        InvokeRepeating("MoveTowards", 0.02f, 0.02f);
        sledge.transform.position = Vector3.MoveTowards(sledge.transform.position, transform.position, moveSpeed);
        Vector3 lookPos = transform.position - sledge.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos);
        sledge.transform.localRotation = lookRot;
    }

    //Continuously moves sledge towards this object
    public void MoveTowards()
    {
        sledge.transform.position = Vector3.MoveTowards(sledge.transform.position, transform.position, moveSpeed);
        if (sledge.transform.position == transform.position)
        {
            CancelInvoke("MoveTowards");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        play.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        play.SetActive(false);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(linkScene);
    }

}
