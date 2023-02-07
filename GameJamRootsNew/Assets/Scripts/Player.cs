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
            transform.Translate(new Vector3(0, 0, speed * 1f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, speed * -1f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(speed * -1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * 1f, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 temp = (mousePosition - transform.position).normalized;
        transform.forward = rotationSpeed * new Vector3(temp.x, 0.0f, temp.z);

        //transform.rotation = Qnew Vector3(transform.rotation.x, 0, transform.rotation.z);

        //transform.LookAt(new Vector3(-Input.mousePosition.x, 0,-Input.mousePosition.z));
        

        //Vector3 rot = new Vector3();
        //rot = Input.mousePosition - transform.position;
        //transform.rotation = Quaternion.EulerRotation(new Vector3(0, rot.normalized.y,0));
    }
}
