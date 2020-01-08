using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_Unlock_Button_Script : MonoBehaviour
{
    public GameObject unlockButton = null;
    public GameObject unlockText = null;

    //Hides the button UI
    public void HideButton()
    {
        gameObject.SetActive(false);
        unlockButton.SetActive(false);
        unlockText.SetActive(false);
        unlockText.GetComponent<Text>().text = "Would you like to unlock this sequence?";
        unlockButton.GetComponent<Unlock_Button_Script>().selectedLevel = null;
    }
}
