using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_To_World_Script : MonoBehaviour
{
    public Coin_Script coinScript;

    public void ReturnToWorld()
    {
        coinScript.ReturnCoinsToWorld();
        SceneManager.LoadScene("World Screen");
    }
}
