using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locking_Script : MonoBehaviour
{
    public bool locked = false;
    public World_Save_Script loadScript;
    public Level_Object parent;

    //Sets lock of parent level from saved data
    public void LoadLocked(int ID)
    {
        locked = (loadScript.lockArray[ID]);
        parent.SetLocked(locked);
    }
}
