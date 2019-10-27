using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_Script : MonoBehaviour
{
    public int coinValue;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Coin_Script.coins += coinValue;
            Destroy(gameObject);
        }
    }
}
