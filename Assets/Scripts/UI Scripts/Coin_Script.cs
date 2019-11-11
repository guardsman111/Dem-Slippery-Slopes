using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Script : MonoBehaviour
{
    private static int levelCoins = 0;

    private void Start()
    {
        levelCoins = 0;
    }

    //Updates UI coin value
    void FixedUpdate()
    {
        this.gameObject.GetComponent<Text>().text = levelCoins.ToString();
    }

    //Adds collected coins to the players coin pot
    //Is global so collectibles do not need a reference to use
    public static void SetLevelCoins(int newCoins)
    {
        levelCoins += newCoins;
    }

    //Adds players new coins to the global coin count
    public void ReturnCoinsToWorld()
    {
        World_Coin_Script.coins += levelCoins;
    }
}
