using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpSpeed = 20f;

    private float moveX;

    public Transform feet;

    public LayerMask groundLayers;

    public Animator animator;

    [HideInInspector] public bool isFacingRight = true;

    public float playerMaxHealth = 3f;

    public float playerCurrHealth;

    private void Start() 
    {
        playerCurrHealth = playerMaxHealth;
    }

    private void Update()
    {   
        moveX = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if(Mathf.Abs(moveX) > 0.05)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(moveX > 0f)
        {
            transform.localScale = new Vector3(4f, 4f, 3f);
            isFacingRight = true;
        }
        else if (moveX < 0f)
        {
            transform.localScale = new Vector3(-4f, 4f, 3f);
            isFacingRight = false;
        }

        animator.SetBool("isGrounded", IsGrounded());

        if(transform.position.y < -15f)
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }


    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpSpeed);

        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundedCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundedCheck != null)
        {
            return true;
        }
        
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "FrogEnemy")
        {
            playerCurrHealth -= 1f;
            if(playerCurrHealth <= 0)
            {
                StartCoroutine(onDeath());
                LevelManager.instance.Respawn();
            }
            else
            {
                StartCoroutine(onHit());
            }
        }    
    }

    IEnumerator onHit() 
    {
        animator.SetBool("isHit", true);
        animator.Play("PlayerHit");
        yield return new WaitForSeconds(.3f);
        animator.SetBool("isHit", false);
    }

    IEnumerator onDeath()
    {
        animator.Play("ItemCollected");
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
