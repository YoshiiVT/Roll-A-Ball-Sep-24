using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    //public float jumpSpeed = 1.0f;
    private Rigidbody rb;

    public int Health = 5;

    public int HitDamage = 1;

    private PlayerScript PlayerScript;

    public bool gameOver = false;

    //Reset Zone Variables
    GameObject resetPoint;
    bool resetting = false;
    Color originalcolour;


    //Controllers
    GameController gameController;

    //Powerups
    [HideInInspector]
    public float baseSpeed;
    Powerup Powerup;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = Speed;
        PlayerScript = GetComponent<PlayerScript>();
        //Gets the rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();



        //Reset Zone Code
        resetPoint = GameObject.Find("Reset Point");
        originalcolour = GetComponent<Renderer>().material.color;
        gameController = FindObjectOfType<GameController>();
        Powerup = FindObjectOfType<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(1);
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
    }
    private void Die()
    {
        print("You Died Sugoi");

        PlayerScript.LoseGame();
    }

    private void FixedUpdate()
    {
        if (gameOver == true)
            return;
       
        if (resetting)
            return;
        
        if (gameController.controlType == ControlType.Worldtilt)
            return;

        //Store the horizontal axis value in a float
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Store the Vertical axis value in a float
        float moveVertical = Input.GetAxis("Vertical");

        //Create a new Vector3 based on the horizontal and vertical values 
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Add force to our rigidbody from our movement vectore * Speed variable
        rb.AddForce(movement * Speed * Time.deltaTime);

        // if (Input.GetButtonDown("Jump"))
        //{

        // rb.AddForce(new Vector3(0, jumpSpeed, 0));
        // }

        //Reset Zone Shit
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }

        if (collision.gameObject.tag == "Hazard")
        {
            TakeDamage(1);
            
            //Need brendans help in adding a delay
            //GetComponent<Renderer>().material.color = Color.red;
        }
    }
    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalcolour;
        resetting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            other.GetComponent<Powerup>().UsePowerup();
            other.gameObject.transform.position = Vector3.up * 10;
        }
    }
}
