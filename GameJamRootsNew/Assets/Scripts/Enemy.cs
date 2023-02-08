using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI enemyHealthText;
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
            StartCoroutine("ResetGame");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
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

                // Needs fix x)
                transform.GetChild(transform.childCount - 1).localScale = Vector3.Lerp(new Vector3 (transform.GetChild(transform.childCount - 1).localScale.x, transform.GetChild(transform.childCount - 1).localScale.y, transform.GetChild(transform.childCount - 1).localScale.z), new Vector3(0, transform.GetChild(transform.childCount - 1).localScale.y, 0), Time.deltaTime * (Time.time - lastShotTime) / shootingInterval);

                if (Time.time - lastShotTime >= shootingInterval)
                {
                    Shoot();
                    lastShotTime = Time.time;
                    // resets the mess happening on line 68
                    transform.GetChild(transform.childCount - 1).localScale = new Vector3(1, 6.28423834f, 1);
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

        if (health >= 0)
        {
            enemyHealthText.text = "Eye's Health: " + health;

        }
        else
        {
            enemyHealthText.text = "Eye's Health: 0";
        }
    }


    IEnumerator ResetGame()
    {
        victoryText.text = "VICTORY!\nRestart in: 3";
        yield return new WaitForSeconds(1);
        victoryText.text = "VICTORY!\nRestart in: 2";
        yield return new WaitForSeconds(1);
        victoryText.text = "VICTORY!\nRestart in: 1";
        yield return new WaitForSeconds(1);
        Player.ResetGame();
    }


}
