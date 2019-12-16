using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Object : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Level number minus 1")]
    private int ID;
    public Locking_Script locker;

    public World_Save_Script loadScript;

    public GameObject sledge;
    public GameObject play;
    public float moveSpeed = 0.3f;
    public string linkedScene;

    public Material unlockedMat;
    public GameObject unlockButton;
    public int levelCost = 1;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int starsAchieved = 0;

    public Level_Object[] linkedLevels;

    [Tooltip("Sequence children cannot be selected unless the sequence parent (the level object with the linked levels array) has been unlocked")]
    public bool isSequenceChild = false;

    void Start()
    {
        CheckStars();
    }

    //Starts player sledge moving towards and rotates sledge to face this object
    public void OnMouseDown()
    {
        if (!locker.locked)
        {
            InvokeRepeating("MoveTowards", 0.02f, 0.02f);
            sledge.transform.position = Vector3.MoveTowards(sledge.transform.position, transform.position, moveSpeed);
            Vector3 lookPos = transform.position - sledge.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookPos);
            sledge.transform.localRotation = lookRot;
        }
        else if (locker.locked)
        {
            if (!isSequenceChild)
            {
                unlockButton.GetComponent<Unlock_Button_Script>().ShowButton();
                unlockButton.GetComponent<Unlock_Button_Script>().selectedLevel = this;
            }
        }
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

    //Sets the level's play button active when the player is over the level object, to prevent random level starting
    public void OnTriggerEnter(Collider other)
    {
        play.SetActive(true);
    }

    //Sets the level's play button inactive
    public void OnTriggerExit(Collider other)
    {
        play.SetActive(false);
    }

    //Sets the number of stars in the world view according to how many stars have previously been achieved
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

    //For setting and getting ID
    public void SetID(int newID)
    {
        ID = newID;
    }

    public int GetID()
    {
        return ID;
    }

    //For setting and getting locked value
    public void SetLocked(bool newV)
    {
        locker.locked = newV;
        if (!locker.locked)
        {
            GetComponent<MeshRenderer>().material = unlockedMat;
            if (linkedLevels != null)
            {
                foreach (Level_Object i in linkedLevels)
                {
                    i.SetLocked(newV);
                }
            }
        }
    }

    public bool GetLocked()
    {
        return locker.locked;
    }

    public void loadComplete()
    {
        locker.LoadLocked(ID);
    }
}
