using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerMouvement : MonoBehaviour
{
    public float Speed;
    public bool isColiding = false;
    public GameObject SpritePlayer;
    SpriteRenderer spriteRenderer;

    //private Vector2 lastPosition;

    public Animator PlayerAnimator;

    void Start()
    {
        spriteRenderer = SpritePlayer.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Vector2 currentPosition = GetComponent<Transform>().position;

        if (!isColiding)
        {
            if (Input.GetKey(KeyCode.D))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed, 0));
                PlayerAnimator.SetBool("PlayerMovement", true);
                spriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(- Speed, 0));
                PlayerAnimator.SetBool("PlayerMovement", true);
                spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + (Speed * Time.deltaTime), transform.position.z);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Speed));
                PlayerAnimator.SetBool("PlayerMovement", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - (Speed * Time.deltaTime), transform.position.z);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -Speed));
                PlayerAnimator.SetBool("PlayerMovement", true);
            }
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                PlayerAnimator.SetBool("PlayerMovement", false);
            }
        } 
        else
        {
            isColiding = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColiding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColiding = false;
    }
}
