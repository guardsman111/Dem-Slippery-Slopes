using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Level_Script : MonoBehaviour
{
    private int ID;
    private string linkScene;
    public World_Script worldScript;

    //Gets id and linked scene from parent level object
    private void Start()
    {
        ID = GetComponentInParent<Level_Object>().GetID();
        linkScene = GetComponentInParent<Level_Object>().linkedScene;
    }

    //Starts the level and sets the static level ID so the game knows which level to add stars too
    public void OnMouseDown()
    {
        World_Script.currentLevelID = ID;
        worldScript.StartLevel(linkScene);
    }

    //Sets ID of the play button to that of its parent level object
    public void SetID(int newID)
    {
        ID = newID;
        this.gameObject.SetActive(false);
    }
    public int GetID()
    {
        return ID;
    }
}
