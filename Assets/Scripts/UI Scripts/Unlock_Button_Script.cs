using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Button_Script : MonoBehaviour
{
    public Level_Object selectedLevel = null;
    public GameObject HideObj = null;

    public void ShowButton()
    {
        gameObject.SetActive(true);
        HideObj.SetActive(true);
    }

    public void unlockLevel()
    {
        if (Star_Script.stars >= selectedLevel.levelCost)
        {
            selectedLevel.SetLocked(false);
            Star_Script.stars -= selectedLevel.levelCost;
            HideObj.GetComponent<Hide_Unlock_Button_Script>().HideButton();
        }
    }
}
