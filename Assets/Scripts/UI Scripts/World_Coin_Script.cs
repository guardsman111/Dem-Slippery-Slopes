using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World_Coin_Script : MonoBehaviour
{
    //Updates UI coin value
    void FixedUpdate()
    {
        this.gameObject.GetComponent<Text>().text = Coin_Script.coins.ToString();
    }
}
