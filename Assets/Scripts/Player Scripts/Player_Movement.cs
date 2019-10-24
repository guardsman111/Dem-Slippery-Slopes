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
    public float strafeSpeed = 3.0f;

    public bool racing = false;
    private bool slowing = true; //used in debugging

    // Start is called before the first frame update
    void Start()
    {
        Rotation = gameObject.transform.eulerAngles.x;
        body = gameObject.GetComponent<Rigidbody>();
        if (Rotation == 0)
        {
            body.velocity = new Vector3(0, -0.5f, speed);
        }
    }

    //Update handles Strafing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            racing = true;
        }
        if (racing)
        {
            //Handles Sideways movement
            if (Input.GetKey(KeyCode.A) && transform.position.x > -2)
            {
                if (body.velocity.x > -strafeSpeed)
                {
                    body.velocity += new Vector3(-0.5f, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.D) && transform.position.x < 2)
            {
                if (body.velocity.x < strafeSpeed)
                {
                    body.velocity += new Vector3(0.5f, 0, 0);
                }
            }
            else if (body.velocity.x > 0)
            {
                body.velocity += new Vector3(-0.5f, 0, 0);
            }
            else if (body.velocity.x < 0)
            {
                body.velocity += new Vector3(0.5f, 0, 0);
            }


            //New Constant Speed
            if (currentSpeed >= speed)
            {
                if (speed > 11)
                    body.velocity -= new Vector3(0, 0.3f, 1f);
                else
                    body.velocity -= new Vector3(0, 0.3f, 0.5f);
                slowing = true;
            }
            else if (currentSpeed < speed)
            {
                if (hitAngle > 339)
                {
                    body.velocity += new Vector3(0, -0.3f, 1f);
                }
                else if (hitAngle > 329)
                {
                    body.velocity += new Vector3(0, -0.3f, 2f);
                }
                else if (hitAngle > 29)
                {
                    body.velocity += new Vector3(0, -0.3f, 0.03f);
                }
                else if (hitAngle > 19)
                {
                    body.velocity += new Vector3(0, -0.3f, 0.03f);
                }
                else if (hitAngle > 9)
                {
                    body.velocity += new Vector3(0, -0.3f, 0.01f);
                }
                else
                {
                    body.velocity += new Vector3(0, -0.3f, 0.5f);
                }
                slowing = false;
            }
        }
        else
        {
            body.velocity = new Vector3(0, 0, 0);
        }
    }

    // Fixed Update handles constant speed
    void FixedUpdate()
    {
        if (racing)
        {
            RaycastHit hit;
            Rotation = gameObject.transform.eulerAngles.x; //Legacy
            currentSpeed = body.velocity.z;

            // Rotate Sledge with ground
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                transform.rotation = Quaternion.RotateTowards(transform.localRotation, hit.collider.GetComponent<Transform>().localRotation, Time.deltaTime * 50f);
            }

            // Get Angle of ground beneath sledge
            hitAngle = hit.collider.GetComponent<Transform>().eulerAngles.x;

            //Calculates max speed based on hit angle
            if (hitAngle > 349)
                if (speed > 8)
                {
                    speed = 8;
                }
            if (hitAngle > 339 && hitAngle <= 349)
                if (speed > 6)
                {
                    speed = 6;
                }
            if (hitAngle > 329 && hitAngle <= 339)
                if (speed > 4)
                {
                    speed = 4;
                }
            if (hitAngle > 0 && hitAngle <= 11)
                if (speed < 12)
                {
                    speed = 12;
                }
            if (hitAngle > 11 && hitAngle <= 21)
                if (speed < 14)
                {
                    speed = 14;
                }
            if (hitAngle > 21 && hitAngle <= 31)
                if (speed < 16)
                {
                    speed = 16;
                }

            /// Legacy Constant Speed
            /// 
            /// 
            /// 
            //// Flat Surface Maintains Speed
            //if (hitAngle == 0)
            //{
            //    if (currentSpeed < speed)
            //    {
            //        body.velocity += new Vector3(0, -4f, 1.0f);
            //    } else
            //    {
            //        body.velocity -= new Vector3(0, 4f, 1.0f);
            //    }
            //}

            //// Small up hill
            //else if (hitAngle > 349)
            //{
            //    speed = 8;
            //    if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, -4f, speed/5);
            //    }
            //    else
            //    {
            //        body.velocity += new Vector3(0, 4f, speed);
            //    }
            //}

            //// Medium up hill
            //else if (hitAngle > 339 && hitAngle <= 349)
            //{
            //    speed = 6;
            //    if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, -4f, speed/5);
            //    }
            //    else
            //    {
            //        body.velocity += new Vector3(0, 4f, speed);
            //    }
            //}

            //// Steep up hill
            //else if (hitAngle > 329 && hitAngle <= 339)
            //{
            //    speed = 4;
            //    if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, -4f, speed/5);
            //    }
            //    else
            //    {
            //        body.velocity += new Vector3(0, 4f, speed);
            //    }
            //}

            //// Small down hill
            //else if (hitAngle > 0 && hitAngle <= 11)
            //{
            //    if (speed < 12)
            //    {
            //        speed = 12;
            //    }
            //    if (currentSpeed < speed - 0.5f)
            //    {
            //        body.velocity += new Vector3(0, -6f, 1.0f);
            //        Debug.Log("speeding");
            //    }
            //    else if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, 6f, 4.0f);
            //        Debug.Log("slowing");
            //    }
            //    else
            //    {
            //        body.velocity -= new Vector3(0, 6f, 0.5f);
            //        Debug.Log("maintaining");
            //    }
            //}

            //// Medium down hill
            //else if (hitAngle > 11 && hitAngle <= 21)
            //{
            //    if (speed < 14)
            //    {
            //        speed = 14;
            //    }
            //    if (currentSpeed < speed - 0.5f)
            //    {
            //        body.velocity += new Vector3(0, -6f, 1.0f);
            //        Debug.Log("speeding");
            //    }
            //    else if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, 6f, 4.0f);
            //        Debug.Log("slowing");
            //    }
            //    else
            //    {
            //        body.velocity -= new Vector3(0, 6f, 2.5f);
            //        Debug.Log("maintaining");
            //    }
            //}

            //// Steep down hill
            //else if (hitAngle > 21 && hitAngle <= 31)
            //{
            //    if (speed < 16)
            //    {
            //        speed = 16;
            //    }
            //    if (currentSpeed < speed - 0.5f)
            //    {
            //        body.velocity += new Vector3(0, -6f, 1.0f);
            //        Debug.Log("speeding");
            //    }
            //    else if (currentSpeed > speed + 1)
            //    {
            //        body.velocity -= new Vector3(0, 6f, 4.0f);
            //        Debug.Log("slowing");
            //    }
            //    else
            //    {
            //        body.velocity -= new Vector3(0, 6f, 5.0f);
            //        Debug.Log("maintaining");
            //    }
            //}
            //else
            //{
            //}
            //Debug.Log(currentSpeed);
            ///
            ///
            /// End Legacy
        }
    }

    //Return Speed for use in other speed based classes
    public int getSpeed()
    {
        return speed;
    }

    //Report used for debugging at slower intervals that update or fixed update
    public void SpeedReport()
    {
        Debug.Log(currentSpeed);
    }
}
