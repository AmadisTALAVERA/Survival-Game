using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator EnemyAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EnemyAnimator.SetBool("EnemyAttack", true);
            Debug.Log("Attaque enemie!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EnemyAnimator.SetBool("EnemyAttack", false);
        }
    }
}
