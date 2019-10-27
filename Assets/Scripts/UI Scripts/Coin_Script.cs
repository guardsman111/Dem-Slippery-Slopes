using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Script : MonoBehaviour
{
    public static int coins = 0;

    void FixedUpdate()
    {
        this.gameObject.GetComponent<Text>().text = coins.ToString();
    }
}
