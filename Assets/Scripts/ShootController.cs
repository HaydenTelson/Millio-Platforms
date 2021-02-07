using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public float fireRate = 0.2f;

    public Transform firingPoint;

    public GameObject bulletPrefab;

    float timeUntilNextShot;
    PlayerMovement playerMovement;


    private void Start() 
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && timeUntilNextShot < Time.time)
        {
            //Maybe make it so a limited number of objects can be fired? Or until one is destroyed
            Shoot();
            timeUntilNextShot = Time.time + fireRate;
        }    
    }

    private void Shoot()
    {
        float angle = playerMovement.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

}
