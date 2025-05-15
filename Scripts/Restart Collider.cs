using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCollider : MonoBehaviour
{
    public bool isTouched;
    public Vector2 StartPosition;

    void Start()
    {
        isTouched = false;
        StartPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        if (isTouched)
        {
            GetComponent<Transform>().position = StartPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy")
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy")
        {
            isTouched = false;
        }
    }
}
