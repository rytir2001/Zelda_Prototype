using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval = 10f;

    private float lastShotTime;
    void Start()
    {
        lastShotTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FindObjectOfType<Player>().transform);

        if (Time.time - lastShotTime >= shootingInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward;
            lastShotTime = Time.time;
        }
    }



}
