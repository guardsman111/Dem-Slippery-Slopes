using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Script : MonoBehaviour
{
    public static int coins = 0;

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

    public static void SetLevelCoins(int newCoins)
    {
        levelCoins += newCoins;
    }

    public void ReturnCoinsToWorld()
    {
        coins += levelCoins;
        Debug.Log("coins added");
    }
}
