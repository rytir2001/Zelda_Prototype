using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;

    private void Update()
    {
        Vector3 direction = transform.forward;
        transform.position += direction * speed * Time.deltaTime;
    }

}
