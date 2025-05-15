using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquareMovement : MonoBehaviour
{
    public float Speed;
    public bool isTrigger;
    public GameObject EnemyCore;

    private Vector2 lastPosition;
    SpriteRenderer spriteRenderer;
    public Animator EnemyAnimator;

    void Start()
    {
        isTrigger = false;
        //StartPosition = GetComponent<Transform>().position;
        lastPosition = EnemyCore.GetComponent<Transform>().position;

        spriteRenderer = EnemyCore.GetComponent<SpriteRenderer>();
    }

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

        Vector2 currentPosition = EnemyCore.GetComponent<Transform>().position;

        float SpeedEnemy = (currentPosition - lastPosition).magnitude;
        if (SpeedEnemy > 0)
            EnemyAnimator.SetBool("EnemyMoving", true);
        else
            EnemyAnimator.SetBool("EnemyMoving", false);


        if (lastPosition.x > currentPosition.x)//inverse anim
            spriteRenderer.flipX = true;
        else if (lastPosition.x < currentPosition.x)
            spriteRenderer.flipX = false;

        lastPosition = currentPosition;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
