using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class World_Save_Script : MonoBehaviour
{
    public World_Script levelArrayHolder;
    public bool[] lockArray;
    private StreamWriter writer;

    //Creates file if it didnt already exist
    public void Start()
    {
        writer = new StreamWriter("SaveDeets.txt", false);
        writer.Close();
    }

    //Saves the world state
    public void SaveLevel()
    {
        writer = new StreamWriter("SaveDeets.txt", false);
        writer.WriteLine(Static_Constant_Script.firstRun);
        foreach (GameObject i in levelArrayHolder.levelIDs)
        {
            writer.WriteLine(i.GetComponent<Level_Object>().starsAchieved);
            writer.WriteLine(i.GetComponent<Level_Object>().GetLocked());
        }
        writer.WriteLine(Star_Script.stars);
        writer.WriteLine(World_Coin_Script.coins);
        writer.Close();
        Debug.Log("Saved");
        Static_Constant_Script.firstRun = false;
    }

    //Loads the world state
    public void LoadLevel()
    {
        StreamReader testReader = new StreamReader("SaveDeets.txt");
        string testLine = testReader.ReadLine();
        if (testLine == null)
        {
            testReader.Close();
            SaveLevel();
        }
        else
        {
            testReader.Close();
        }
        StreamReader reader = new StreamReader("SaveDeets.txt");
        lockArray = new bool[levelArrayHolder.levelIDs.Length];
        int count = 0;
        string firstRun = reader.ReadLine();
        if (firstRun == "False")
        {
            Static_Constant_Script.firstRun = false;
        }
        else
        {
            Static_Constant_Script.firstRun = true;
        }
        foreach (GameObject i in levelArrayHolder.levelIDs)
        {
            string tempLine = reader.ReadLine();
            i.GetComponent<Level_Object>().starsAchieved = int.Parse(tempLine);
            string tempLock = reader.ReadLine();
            if (tempLock == "True")
            {
                lockArray[count] = true;
            }
            else if (tempLock == "False")
            {
                lockArray[count] = false;
            }
            count++;
            i.GetComponent<Level_Object>().loadComplete();
        }
        Star_Script.stars = int.Parse(reader.ReadLine());
        if (World_Coin_Script.coins == 0)
        {
            World_Coin_Script.coins = int.Parse(reader.ReadLine());
        }
        Debug.Log("Loaded");
    }
}
