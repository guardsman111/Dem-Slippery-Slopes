using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class World_Save_Script : MonoBehaviour
{
    public World_Script levelArrayHolder;
    private StreamWriter writer;

    public void SaveLevel()
    {
        writer = new StreamWriter("SaveDeets.txt", false);
        foreach (GameObject i in levelArrayHolder.levelIDs)
        {
            writer.WriteLine(i.GetComponent<Level_Object>().starsAchieved);
            writer.WriteLine(i.GetComponent<Level_Object>().GetLocked());
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
            string tempLock = reader.ReadLine();
            if (tempLock == "false")
            {
                i.GetComponent<Level_Object>().SetLocked(false);
            }
        }
        Star_Script.stars = int.Parse(reader.ReadLine());
        World_Coin_Script.coins = int.Parse(reader.ReadLine());
        Debug.Log("Loaded");
    }
}
