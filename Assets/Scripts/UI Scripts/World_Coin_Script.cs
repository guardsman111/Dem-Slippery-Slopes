﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World_Coin_Script : MonoBehaviour
{
    public static int coins = 0;

    //Updates UI coin value
    void FixedUpdate()
    {
        this.gameObject.GetComponent<Text>().text = coins.ToString();
    }
}
