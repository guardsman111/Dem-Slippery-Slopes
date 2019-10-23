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
    }

    //Update handles Strafing
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > -2)
        {
            if (body.velocity.x > -1)
            {
                body.velocity += new Vector3(-0.3f, 0, 0);
                Debug.Log("A Pressed");
            }
            Debug.Log(body.velocity.x);
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < 2)
        {
            if (body.velocity.x < 1)
            {
                body.velocity += new Vector3(0.3f, 0, 0);
                Debug.Log("D Pressed");
            }
            Debug.Log(body.velocity.x);
        } 
        else if (body.velocity.x > 0)
        {
            body.velocity += new Vector3(-0.5f, 0, 0);
        }
        else if (body.velocity.x < 0)
        {
            body.velocity += new Vector3(0.5f, 0, 0);
        }
    }

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
            if (currentSpeed < speed)
            {
                body.velocity += new Vector3(0, -4f, 1.0f);
            } else
            {
                body.velocity -= new Vector3(0, 4f, 1.0f);
            }
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
                body.velocity = new Vector3(0, 0, speed);
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
                body.velocity = new Vector3(0, 0, speed);
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
                body.velocity = new Vector3(0, 0, speed);
            }
        }
        else if (hitAngle > 0 && hitAngle <= 11)
        {
            if (speed < 12)
            {
                speed = 12;
            }
            if (currentSpeed < speed - 0.5f)
            {
                body.velocity += new Vector3(0, -4f, 1.0f);
                Debug.Log("speeding");
            }
            else if (currentSpeed > speed + 1)
            {
                body.velocity -= new Vector3(0, 6f, 2.0f);
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
            if (speed < 14)
            {
                speed = 14;
            }
            if (currentSpeed < speed - 0.5f)
            {
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
            if (speed < 16)
            {
                speed = 16;
            }
            if (currentSpeed < speed - 0.5f)
            {
                body.velocity += new Vector3(0, -4f, 1.0f);
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
