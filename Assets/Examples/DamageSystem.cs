using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int Health = 10;
    // If you dont have a value after a variable, it will defalt at 0

    public int CannonDamage = 2;
    public int BulletDamage = 1;
    public int BoulderDamage = 3;

    [Header("Arrays")]
    public GameObject[] enemies;
    public GameObject enemy;
    public int enemyAmount = 10;

    void Start()
    {
        for (int i = 0; i < enemyAmount; i++) 
        {
            Instantiate(enemy, new Vector3(Random.Range(-10,10), Random.Range(5, 15), 0), transform.rotation);
        }

        for (int i = 0; i < enemies.Length; i++)
        { 
            print(enemies[i].name);
        }
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeDamage(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(3);
        }
    }
    
    private void TakeDamage(int _damage)
    {
        Health -= _damage;

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
          
   

        print(Health);
    }

    private void Die()
    {
        print("You Died SUGOI");
        Destroy(gameObject,3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cannon")
        {
            TakeDamage(CannonDamage);
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (collision.gameObject.name == "Bullet")
        {
            TakeDamage(BulletDamage);
            GetComponent<Renderer>().material.color = Color.magenta;
        }

        if (collision.gameObject.name == "Boulder")
        {
            TakeDamage(BoulderDamage);
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}

