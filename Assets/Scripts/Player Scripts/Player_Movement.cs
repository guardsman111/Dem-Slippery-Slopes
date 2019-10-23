using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float Rotation;
    private int speed = 10;
    private float hitAngle = 0;
    private float currentSpeed = 0;
    private Rigidbody body;
    public Transform parent;

    private bool flat = true;

    // Start is called before the first frame update
    void Start()
    {
        Rotation = gameObject.transform.eulerAngles.x;
        body = gameObject.GetComponent<Rigidbody>();
        if (Rotation == 0)
        {
            body.velocity = new Vector3 ( 0, -0.5f, speed);
        }
        Time.timeScale = 0.5f;
    }

    // Update handles Strafing
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        if (transform.position.x > -5)
    //        {
    //            body.velocity += new Vector3(-10f, 0, 0);
    //        }
    //        Debug.Log("A Pressed");
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        if (transform.position.x < 5)
    //        {
    //            body.velocity += new Vector3(10f, 0, 0);
    //        }
    //        Debug.Log("D Pressed");
    //    }
    //}

    // Fixed Update handles constant speed
    void FixedUpdate()
    {
        RaycastHit hit;
        Rotation = gameObject.transform.eulerAngles.x; //Legacy
        currentSpeed = body.velocity.magnitude;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, hit.collider.GetComponent<Transform>().localRotation, Time.deltaTime * 40f);
        }

        hitAngle = hit.collider.GetComponent<Transform>().eulerAngles.x;

        if (hitAngle == 0)
        {
            if (!flat)
            {
                speed = (int)currentSpeed;
            }
            body.velocity = new Vector3(0, -4f, speed);
            flat = true;
        }
        else if (hitAngle > 349)
        {
            flat = false;
            speed = 8;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                body.velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 339 && hitAngle <= 349)
        {
            flat = false;
            speed = 6;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                body.velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 329 && hitAngle <= 339)
        {
            flat = false;
            speed = 4;
            if (currentSpeed > speed + 1)
            {
                //physics slows it down
            }
            else
            {
                body.velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 0 && hitAngle <= 11)
        {
            flat = false;
            if (speed < 12)
            {
                speed = 12;
            }
            if (currentSpeed < speed - 0.5f)
            {
                //physics speeds it up
                Debug.Log("speeding");
            }
            else if (currentSpeed > speed + 1)
            {
                body.velocity -= new Vector3(0, 6f, 1.0f);
                Debug.Log("slowing");
            }
            else
            {
                body.velocity -= new Vector3(0, 6f, 0.5f);
                Debug.Log("maintaining");
            }
        }
        else if (hitAngle > 11 && hitAngle <= 21)
        {
            flat = false;
            if (speed < 14)
            {
                speed = 14;
            }
            if (currentSpeed < speed - 0.5f)
            {
                //physics speeds it up
                Debug.Log("speeding");
            }
            else if (currentSpeed > speed + 1)
            {
                body.velocity -= new Vector3(0, 6f, 4.0f);
                Debug.Log("slowing");
            }
            else
            {
                body.velocity -= new Vector3(0, 6f, 2.5f);
                Debug.Log("maintaining");
            }
        }
        else if (hitAngle > 21 && hitAngle <= 31)
        {
            flat = false;
            if (speed < 16)
            {
                speed = 16;
            }
            if (currentSpeed < speed - 0.5f)
            {
                //physics speeds it up
                Debug.Log("speeding");
            }
            else if (currentSpeed > speed + 1)
            {
                body.velocity -= new Vector3(0, 6f, 8.0f);
                Debug.Log("slowing");
            }
            else
            {
                body.velocity -= new Vector3(0, 6f, 5.0f);
                Debug.Log("maintaining");
            }
        }
        else
        {
        }
        Debug.Log(currentSpeed);
    }
}
