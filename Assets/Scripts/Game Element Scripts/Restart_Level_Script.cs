using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Level_Script : MonoBehaviour
{
    public string currentSceneName;

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneName);
        Debug.Log("Reloading");
    }
}
