using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum eState
{
    attack = 0,
    stagger = 1
}

public class Enemy : MonoBehaviour
{
  
    public GameObject bulletPrefab;
    public GameObject platform;
    public int health = 10;
    public int amountOfBulletNeeded = 2;
    public float shootingInterval = 10f;
    public eState myState = eState.attack;
    public float staggerDuration = 10f;
    private float lastShotTime;
    private int amountOfHits = 0;
    private float startStagger = 0;
    void Start()
    {
        platform.SetActive(false);
        lastShotTime = Time.time;
        startStagger = Time.time;
    }


    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.forward = transform.forward;
    }
    public void TakeDamage() 
    {
        health--;
        if (health <= 0) 
        {
            //enemy dies;
        }
    }
    public void OnHit() 
    {
        amountOfHits++;
       
        if (amountOfHits == amountOfBulletNeeded)
        {
            amountOfHits = 0;
            myState = eState.stagger;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        switch (myState) 
        {
            case eState.attack:

                transform.LookAt(FindObjectOfType<Player>().transform);

                if (Time.time - lastShotTime >= shootingInterval)
                {
                    Shoot();
                    lastShotTime = Time.time;
                }
             
                break;
            case eState.stagger:

                platform.SetActive(true);
                if (Time.time - startStagger >= staggerDuration) 
                {
                    platform.SetActive(false);

                    startStagger = Time.time;
                    myState = eState.attack;

                }
                break;    
        }

      
    }



}
