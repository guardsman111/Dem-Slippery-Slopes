using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Object : MonoBehaviour
{
    [SerializeField]
    private int ID;
    public GameObject sledge;
    public GameObject play;
    public float moveSpeed = 0.3f;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int starsAchieved = 0;

    void Awake()
    {
        CheckStars();
    }
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

    public void CheckStars()
    {
        switch (starsAchieved)
        {
            case 1:
                    star1.SetActive(true);
                    star2.SetActive(false);
                    star3.SetActive(false);
                break;
            case 2:
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(false);
                break;
            case 3:
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);
                break;
            default:
                    star1.SetActive(false);
                    star2.SetActive(false);
                    star3.SetActive(false);
                break;
        }
    }

    public void SetID(int newID)
    {
        ID = newID;
    }

    public int GetID()
    {
        return ID;
    }
}
