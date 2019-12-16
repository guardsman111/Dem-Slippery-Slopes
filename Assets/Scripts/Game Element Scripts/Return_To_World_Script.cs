using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_To_World_Script : MonoBehaviour
{
    public Coin_Script coinScript;
    public bool noWin;

    public void ReturnToWorld()
    {
        if (!noWin)
        {
            coinScript.ReturnCoinsToWorld();
            Debug.Log(World_Coin_Script.coins);
            SceneManager.LoadScene("World Screen");
        }
        else
        {
            SceneManager.LoadScene("World Screen");
        }
    }
}
