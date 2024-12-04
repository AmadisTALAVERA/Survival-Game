using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquareMovement : MonoBehaviour
{
    public float Speed;
    public bool isTrigger;
    public GameObject EnemyCore;

    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
        //StartPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            EnemyCore.GetComponent<Transform>().position = Vector2.MoveTowards(EnemyCore.GetComponent<Transform>().position, GameManager.Instance.Player.GetComponent<Transform>().position, Speed * Time.deltaTime);
        }
        else
        {
            EnemyCore.GetComponent<Transform>().position = Vector2.MoveTowards(EnemyCore.GetComponent<Transform>().position, GetComponent<Transform>().position, Speed * Time.deltaTime);
        }
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
}
