using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Script : MonoBehaviour
{
    public Player_Movement parent;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = parent.getSpeed();
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3 (0, 3.06f,-parent.getSpeed() / 2), 1 * Time.deltaTime);
        if (speed <= 8)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(30, 0, 0), Time.deltaTime * 10f);
        }
        else if (speed > 8)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(15, 0, 0), Time.deltaTime * 10f);
        }
    }

    private void FixedUpdate()
    {
        if (speed > 10)
        {
            if (speed == 12)
            {
                transform.localPosition += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
            }
            if (speed == 14)
            {
                transform.localPosition += new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f));
            }
            if (speed == 16)
            {
                transform.localPosition += new Vector3(Random.Range(-0.03f, 0.03f), Random.Range(-0.03f, 0.03f));
            }
        }
    }
}
