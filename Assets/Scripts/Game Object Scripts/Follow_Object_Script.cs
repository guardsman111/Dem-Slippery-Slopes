using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Object_Script : MonoBehaviour
{
    public Transform target;

    // Follows the players object but does not rotate
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = target.position - new Vector3(-1.4f, -14.1f, -20.3f);
    }
}
