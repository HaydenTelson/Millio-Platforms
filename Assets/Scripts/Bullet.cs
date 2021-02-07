using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;

    public Rigidbody2D rb;

    private void FixedUpdate() 
    {
        rb.velocity = transform.right * bulletSpeed;    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground" || other.collider.tag == "Berry")
        {
            Destroy(gameObject);
        }
    }
}
