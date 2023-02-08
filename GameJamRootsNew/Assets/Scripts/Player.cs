using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
enum eEquiped
{
    Shooting = 0,
    Melee = 1
}
public class Player : MonoBehaviour
{
    Enemy enemy;
    public GameObject bullet;
    public float speed = 1.0f;
    public float rotationSpeed = 1f;
    public static int playerHealth = 3;
    eEquiped myEquipment = eEquiped.Shooting;
    bool isInContact = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    
    void UpdateMovement()
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

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 temp = (mousePosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(rotationSpeed * Time.deltaTime * new Vector3(temp.x, 0.0f, temp.z));
    }

  
 
    private void OnCollisionStay(Collision collision)
    {
        if (this.name.Contains("Player") && collision.gameObject.name.Contains("Eye"))
        {
            isInContact = true;
        }
        else isInContact = false;
    }
    void Update()
    {
  
        UpdateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (myEquipment == eEquiped.Melee)
            {
                myEquipment = eEquiped.Shooting;
            }
            else myEquipment = eEquiped.Melee;
        }

        switch (myEquipment) 
        {
            case eEquiped.Shooting:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                }
                break;
            case eEquiped.Melee:

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (isInContact) 
                    {
                        enemy.TakeDamage();
                        print(enemy.health);
                    }

                }
            
                break;
            
        }
      
       

        if (playerHealth == 0 || transform.position.y <= -1)
        {
            SceneManager.UnloadSceneAsync("Zelda");
            SceneManager.LoadScene("Zelda");
        }
      
    }

}
