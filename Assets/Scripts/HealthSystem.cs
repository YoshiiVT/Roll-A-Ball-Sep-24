using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Health = 5;

    public int HitDamage = 1;

    private PlayerScript PlayerScript;

    private void Start()
    {
        PlayerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage (int _damage)
    {
        Health -= _damage;

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }
    private void Die()
    {
        print ("You Died Sugoi");
       
        PlayerScript.LoseGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            TakeDamage(1);
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

