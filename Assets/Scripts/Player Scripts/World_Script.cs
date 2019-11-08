using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World_Script : MonoBehaviour
{
    private GameObject moveTarget;
    public static int currentLevelID = 0;
    public static int starsAchieved = 0;
    public GameObject[] levelIDs;

    public void Awake()
    {
        int count = 0;
        levelIDs = new GameObject[100];
        levelIDs = GameObject.FindGameObjectsWithTag("Level");
        foreach (GameObject i in levelIDs)
        {
            i.GetComponent<Level_Object>().SetID(count);
            i.GetComponentInChildren<Play_Level_Script>().SetID(count);
            count += 1;
        }
        levelIDs[currentLevelID].GetComponent<Level_Object>().starsAchieved = starsAchieved;
        Star_Script.stars += starsAchieved;
    } 

    public void StartLevel(string linkScene)
    {
        SceneManager.LoadScene(linkScene);
    }
}
