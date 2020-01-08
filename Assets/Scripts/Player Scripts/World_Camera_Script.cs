using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Camera_Script : MonoBehaviour
{
    public float moveSpeed = 0.3f;

    //Moves camera by moveSpeed when button keys are pressed
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }
    }
}
