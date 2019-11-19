using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class World_Script : MonoBehaviour
{
    private GameObject moveTarget;
    public static int currentLevelID = 0;
    public static int starsAchieved = 0;
    public GameObject[] levelIDs;
    public GameObject[] levelObjects;

    //Organizes levels array by numerical value and adds achieved stars to Level Object
    public void Awake()
    {
        levelObjects = new GameObject[100];
        levelIDs = new GameObject[100];
        levelObjects = GameObject.FindGameObjectsWithTag("Level");
        levelIDs = levelObjects.OrderBy(level => level.GetComponent<Level_Object>().GetID()).ToArray();

        levelIDs[currentLevelID].GetComponent<Level_Object>().starsAchieved = starsAchieved;
        Star_Script.stars += starsAchieved;
        Debug.Log("Stars Added");
        Debug.Log(starsAchieved);
    } 

    //Loads level scene
    public void StartLevel(string linkScene)
    {
        SceneManager.LoadScene(linkScene);
    }
}
