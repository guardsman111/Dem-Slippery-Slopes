using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Script : MonoBehaviour
{
    public Player_Movement parent;
    public int speed;

    //Based on player Movement racing in fixed update
    private bool raceCheck;


    //Update keeps the camera focused on the sledge and zooms and rotates depending on speed
    void Update()
    {
        if (raceCheck)
        {
            speed = parent.getSpeed();
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 2.45f, -parent.getSpeed() / 2), 1 * Time.deltaTime);
            if (speed <= 8)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(30, 0, 0), Time.deltaTime * 10f);
            }
            else if (speed > 8)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(15, 0, 0), Time.deltaTime * 10f);
            }
        }
    }

    //Fixed Update shakes to camera to give the effect of high speed
    private void FixedUpdate()
    {
        raceCheck = parent.racing;
        if (raceCheck)
        {
            if (speed > 10)
            {
                if (speed == 12)
                {
                    transform.localPosition += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
                }
                if (speed == 14)
                {
                    transform.localPosition += new Vector3(Random.Range(-0.03f, 0.03f), Random.Range(-0.03f, 0.03f));
                }
                if (speed == 16)
                {
                    transform.localPosition += new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
                }
            }
        }
    }
}
