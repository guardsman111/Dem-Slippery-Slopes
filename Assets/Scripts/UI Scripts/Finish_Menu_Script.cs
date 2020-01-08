using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish_Menu_Script : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public Text Text;
    public Text Clock;
    public Sprite failBackground;

    public void CountStars(int stars)
    {
        Text.text = Clock.text;
        if (stars == 1)
        {
            Star1.SetActive(true);
        }
        if (stars == 2)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        if (stars == 3)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
    }

    public void RunFail()
    {
        GetComponent<Image>().sprite = failBackground;
        Text.gameObject.SetActive(false);
    }
}
