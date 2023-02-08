using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 1.0f;
    public float rotationSpeed = 1f;
    public static int playerHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 movement = new Vector3();// transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1f;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1f;
        }
        float tempSpeed = speed * Time.deltaTime;
        movement *= tempSpeed;
     
        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position ,transform.rotation);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 temp = (mousePosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(rotationSpeed * Time.deltaTime * new Vector3(temp.x, 0.0f, temp.z));

        if (playerHealth == 0 || transform.position.y <= -1)
        {
            SceneManager.UnloadSceneAsync("Zelda");
            SceneManager.LoadScene("Zelda");
        }
      
    }

}
