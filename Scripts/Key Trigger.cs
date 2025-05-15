using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public DoorTrigger door;

    void Start()
    {
      
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door.isClosed = false;
            GameObject.Destroy(gameObject);

        }
    }
}
