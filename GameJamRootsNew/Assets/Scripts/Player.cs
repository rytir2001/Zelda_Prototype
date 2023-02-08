using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 0.01f;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed * 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, speed * -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(speed * -1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * 1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position ,transform.rotation);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 temp = (mousePosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(rotationSpeed * new Vector3(temp.x, 0.0f, temp.z));

      
    }
}
