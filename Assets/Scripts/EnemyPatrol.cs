using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   public float speed = 2f;

   public Rigidbody2D rb;

   public LayerMask groundLayers;

    public Transform groundCheck;

    bool isFacingRight = true;

    RaycastHit2D hit2D;
    public Animator animator;

    public float hitPoints = 100f;

    public float currHealth;


    private void Start() 
    {
        currHealth = hitPoints;  
    }


    private void Update() 
    {
        hit2D = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);

        if(speed > 0.05)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(currHealth <= 0)
        {
            StartCoroutine(onDeath());
        }
    }

    private void FixedUpdate() 
    {
        if(hit2D.collider != false)
        {
            if(isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }    
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 4f, 4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Bullet")
        {
            animator.Play("FrogHit");
            Destroy(other.gameObject);
            currHealth -= 50;
        }
    }

    IEnumerator onDeath()
    {
        animator.Play("ItemCollected");
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }


}
