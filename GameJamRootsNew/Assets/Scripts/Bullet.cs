using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;
    Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void Update()
    {
        Vector3 direction = transform.forward;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.name.Contains("Var") && other.name.Contains("Player"))
        {
            Player.playerHealth--;
        }

        if ((this.name.Contains("Var") && other.name.Contains("Eye")) || (!this.name.Contains("Var") && other.name.Contains("Player")) || other.name.Contains("Bullet"))
        {
            // nothing happening here on purpose, it's for the else result
        }
        else
        {
            Destroy(gameObject);
        }

        if (!this.name.Contains("Var") && other.name.Contains("Eye"))
        {
            enemy.OnHit();
        }
    }
}
