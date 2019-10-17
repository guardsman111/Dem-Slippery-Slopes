using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float Rotation;
    private int speed = 10;
    private float hitAngle = 0;
    private float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rotation = gameObject.transform.eulerAngles.x;
        if (Rotation == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3 ( 0, -0.5f, speed);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Rotation = gameObject.transform.eulerAngles.x; //Legacy
        currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, hit.collider.GetComponent<Transform>().localRotation, Time.deltaTime * 40f);
        }

        hitAngle = hit.collider.GetComponent<Transform>().eulerAngles.x;

        if (hitAngle == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
            Debug.Log(speed);
        }
        else if (hitAngle > 349)
        {
            speed = 8;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 339 && hitAngle <= 349)
        {
            speed = 6;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 329 && hitAngle <= 339)
        {
            speed = 4;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 0 && hitAngle <= 11)
        {
            if (speed < 12)
            {
                speed = 12;
            }
            if (currentSpeed < speed - 1)
            {
                gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0, -6f, speed / 15);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -6f, speed);
            }
        }
        else if (hitAngle > 11 && hitAngle <= 21)
        {
            if (speed < 14)
            {
                speed = 14;
            }
            if (currentSpeed < speed - 1)
            {
                gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0, -20f, speed / 15);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -20f, speed);
            }
        }
        else if (hitAngle > 21 && hitAngle <= 31)
        {
            if (speed < 16)
            {
                speed = 16;
            }
            if (currentSpeed < speed - 1)
            {
                gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0, -20f, speed / 15);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -20f, speed);
            }
        }
        else
        {
            Debug.Log(hitAngle);
        }
        Debug.Log(hitAngle);
        Debug.Log(currentSpeed);
    }
}
