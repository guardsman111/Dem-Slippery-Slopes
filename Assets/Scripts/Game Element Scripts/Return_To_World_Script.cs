using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_To_World_Script : MonoBehaviour
{
    public void ReturnToWorld()
    {
        SceneManager.LoadScene("World Screen");
    }
}
