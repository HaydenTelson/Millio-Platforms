using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryController : MonoBehaviour
{
    public Animator animator;
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Player")
        {
            StartCoroutine(onPickup());
        }
    }

    IEnumerator onPickup()
    {
        animator.Play("ItemCollected");
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject); 

    }






}
