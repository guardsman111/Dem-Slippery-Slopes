using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Level_Script : MonoBehaviour
{
    [SerializeField]
    private int ID;
    public World_Script worldScript;
    public string linkScene;

    public void OnMouseDown()
    {
        World_Script.currentLevelID = ID;
        worldScript.StartLevel(linkScene);
    }

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
