using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyCircleMovement : MonoBehaviour
{
    public float Speed;
    public bool isTrigger;
    //public bool isColiding = false;

    public Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
        StartPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isColiding)
        //{ 
        if (isTrigger)
        {
            GetComponent<Transform>().position = Vector2.MoveTowards(GetComponent<Transform>().position, GameManager.Instance.Player.GetComponent<Transform>().position, Speed * Time.deltaTime);
        } else
        {
            GetComponent<Transform>().position = Vector2.MoveTowards(GetComponent<Transform>().position, StartPosition, Speed * Time.deltaTime);
        }
        /*}
        else
        {
            //isColiding = false;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        //isColiding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //isColiding = false;
    }
    */
}
