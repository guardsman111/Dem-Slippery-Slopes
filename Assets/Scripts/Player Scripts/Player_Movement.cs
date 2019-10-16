using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float Rotation;
    private int speed = 10;

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

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, hit.collider.GetComponent<Transform>().localRotation, Time.deltaTime * 10f);

        if (Rotation == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation < 0 && Rotation >= -10)
        {
            speed = 8;
            //while currentSpeed (velocity.magnitude) is less than or greater than speed, add or remove velocity until currentSpeed == speed
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation < -10 && Rotation >= -20)
        {
            speed = 6;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation < -20 && Rotation >= -30)
        {
            speed = 4;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation > 0 && Rotation <= 10)
        {
            speed = 12;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation > 10 && Rotation <= 20)
        {
            speed = 14;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
        if (Rotation > 20 && Rotation <= 30)
        {
            speed = 16;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, speed);
        }
    }
}
