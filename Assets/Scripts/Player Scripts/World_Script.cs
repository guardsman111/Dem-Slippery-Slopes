﻿using System;
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
    public World_Save_Script saveLoader;
    public GameObject startMenu;
    private bool firstLoad = true;

    //Organizes levels array by numerical value and adds achieved stars to Level Object
    public void Awake()
    {
        if (firstLoad == false)
        {

        }
        firstLoad = false;
        levelObjects = new GameObject[100];
        levelIDs = new GameObject[100];
        levelObjects = GameObject.FindGameObjectsWithTag("Level");
        levelIDs = levelObjects.OrderBy(level => level.GetComponent<Level_Object>().GetID()).ToArray();
        saveLoader.LoadLevel();
        levelIDs[currentLevelID].GetComponent<Level_Object>().starsAchieved = starsAchieved;
        Star_Script.stars += starsAchieved;
        Debug.Log("Stars Added");
        Debug.Log(starsAchieved);
    } 

    //Loads level scene
    public void StartLevel(string linkScene)
    {
        saveLoader.SaveLevel();
        SceneManager.LoadScene(linkScene);
    }

    //Menu stuff, to allow exit and saving of game
    //commented out stuff is for debugging
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        //if (Input.GetKey(KeyCode.B))
        //{
        //    saveLoader.SaveLevel();
        //}

        //if (Input.GetKey(KeyCode.N))
        //{
        //    SceneManager.LoadScene("World Screen");
        //}
    }
}
