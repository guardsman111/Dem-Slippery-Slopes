using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Level_Script : MonoBehaviour
{
    public Level_Object parent;

    public void OnMouseDown()
    {
        parent.StartLevel();
    }
}
