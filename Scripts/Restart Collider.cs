using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCollider : MonoBehaviour
{
    public bool isTouched;
    public Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        StartPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            GetComponent<Transform>().position = StartPosition;
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Enemy")
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit(Collider enemy)
    {
        if (enemy.tag == "Enemy")
        {
            isTouched = false;
        }
    }
}
