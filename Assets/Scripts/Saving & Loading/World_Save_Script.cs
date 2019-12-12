using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class World_Save_Script : MonoBehaviour
{
    public World_Script levelArrayHolder;
    private StreamWriter writer;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveLevel();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadLevel();
        }
    }

    public void SaveLevel()
    {
        writer = new StreamWriter("SaveDeets.txt", false);
        foreach (GameObject i in levelArrayHolder.levelIDs)
        {
            writer.WriteLine(i.GetComponent<Level_Object>().starsAchieved);
        }
        writer.WriteLine(Star_Script.stars);
        writer.WriteLine(World_Coin_Script.coins);
        writer.Close();
        Debug.Log("Saved");
    }
    public void LoadLevel()
    {
        StreamReader reader = new StreamReader("SaveDeets.txt");
        foreach (GameObject i in levelArrayHolder.levelIDs)
        {
            string tempLine = reader.ReadLine();
            i.GetComponent<Level_Object>().starsAchieved = int.Parse(tempLine);
        }
        Star_Script.stars = int.Parse(reader.ReadLine());
        World_Coin_Script.coins = int.Parse(reader.ReadLine());
        Debug.Log("Loaded");
    }
}
