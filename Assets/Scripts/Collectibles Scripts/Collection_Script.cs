using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_Script : MonoBehaviour
{
    public int coinValue;

    //On Collision with collectable, destroy collectable and add coin value too global coins
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Coin_Script.coins += coinValue;
            Destroy(gameObject);
        }
    }
}
