using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        transform.forward = FindObjectOfType<Player>().transform.forward.normalized;
    }

    private void Update()
    {
        transform.Translate(transform.forward * 0.01f);
    }

}
