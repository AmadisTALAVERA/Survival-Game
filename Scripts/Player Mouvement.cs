using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerMouvement : MonoBehaviour
{
    public float Speed;
    public bool isColiding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isColiding)
        {
            if (Input.GetKey(KeyCode.D))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                GetComponent<Rigidbody>().AddForce(Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                GetComponent<Rigidbody>().AddForce(-Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + (Speed * Time.deltaTime), transform.position.z);
                GetComponent<Rigidbody>().AddForce(0, Speed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - (Speed * Time.deltaTime), transform.position.z);
                GetComponent<Rigidbody>().AddForce(0, -Speed, 0);
            }
        } 
        else
        {
            isColiding = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isColiding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColiding = false;
    }
}
