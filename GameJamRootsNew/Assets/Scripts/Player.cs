using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
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
    public TextMeshProUGUI healthText;
    private Animator myAnimator;
    public GameObject bullet;
    public float speed = 1.0f;
    public float rotationSpeed = 1f;
    public static int playerHealth = 3;
    public int maxHealth = 3;
    eEquiped myEquipment = eEquiped.Shooting;
    bool isInContact = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = transform.GetChild(0).GetComponent<Animator>();
       
       
        playerHealth = maxHealth;
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

        if(movement.x == 0 && movement.z ==0) 
        {
            myAnimator.SetBool("walking", false);
        }
        else myAnimator.SetBool("walking", true);
        

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
    void shoot() 
    {
        //if (!AnimatorIsPlaying("HeroCharacter|Blowgun"))
        {
           // myAnimator.SetBool("shooting", true);
            Instantiate(bullet, transform.position, transform.rotation);
        }
       
    }
    bool AnimatorIsPlaying()
    {
        return myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && myAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
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
                    shoot();
                    
                }
                //else myAnimator.SetBool("shooting", false);

                break;
         
            case eEquiped.Melee:

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (isInContact) 
                    {
                        //myAnimator.SetBool("melee", true);
                        if (enemy.health > 0)
                        {
                            enemy.TakeDamage();
                        }
                       

                    }

                }
            
                break;
            
        }

        healthText.text = "Health: " + playerHealth;

        if (playerHealth <= 0 || transform.position.y <= -1)
        {
            ResetGame();
        }
      
    }
    
    public static void ResetGame()
    {
        SceneManager.LoadScene("Zelda");
    }

}
