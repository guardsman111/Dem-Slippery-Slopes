using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Level_Script : MonoBehaviour
{
    [SerializeField]
    private int ID;
    public World_Script worldScript;
    public string linkScene;

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
