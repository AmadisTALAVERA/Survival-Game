using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isClosed = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (isClosed == false)
        {
            print("hey");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Start");
    }
}
