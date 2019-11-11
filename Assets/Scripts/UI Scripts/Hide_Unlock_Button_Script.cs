using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Unlock_Button_Script : MonoBehaviour
{
    public GameObject UnlockButton = null;
    
    public void HideButton()
    {
        gameObject.SetActive(false);
        UnlockButton.SetActive(false);
        UnlockButton.GetComponent<Unlock_Button_Script>().selectedLevel = null;
    }
}
