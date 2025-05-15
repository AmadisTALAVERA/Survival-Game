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
    private Vector2 lastPosition;

    public GameObject SpriteEnemy;
    SpriteRenderer spriteRenderer;
    public Animator EnemyAnimator;

    void Start()
    {
        isTrigger = false;
        StartPosition = GetComponent<Transform>().position;
        lastPosition = GetComponent<Transform>().position;
        spriteRenderer = SpriteEnemy.GetComponent<SpriteRenderer>();
    }

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

        Vector2 currentPosition = GetComponent<Transform>().position;

        float SpeedEnemy = (currentPosition - lastPosition).magnitude;
        if (SpeedEnemy > 0)
            EnemyAnimator.SetBool("EnemyMoving", true);
        else
            EnemyAnimator.SetBool("EnemyMoving", false);

        if (lastPosition.x > currentPosition.x)
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
