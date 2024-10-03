using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpSpeed = 1.0f;
    private Rigidbody rb;
    private int pickupCount;

    void Start()
    {
        //Gets the rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
        //Gets the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Run the CheckPickups Function
        CheckPickups();
    }

    void FixedUpdate()
    {
        //Store the horizontal axis value in a float
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Store the Vertical axis value in a float
        float moveVertical = Input.GetAxis("Vertical");

        //Create a new Vector3 based on the horizontal and vertical values 
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Add force to our rigidbody from our movement vectore * Speed variable
        rb.AddForce(movement * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {

            rb.AddForce(new Vector3(0, jumpSpeed, 0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            //Destroy the collided Object
            Destroy(other.gameObject);
            //Decrement the pickup count
            pickupCount--;
            // Run the Check Pickups Function
            CheckPickups();
        }

    }
    private void CheckPickups()
    {
        print("Pickups left: " + pickupCount);
        if(pickupCount == 0)
        {
            Wingame();
        }
    }

    private void Wingame()
    {
        print("SUGOI!! You win!");
    }
}


//<This is called a comment, the system completely ignores this.
//Variables = Something that will change
//Constant = Something that never changes
//For Games, variables are the building blocks
//Variables are the first thing in the scrips
//Int=Interger (Which is a whole number)
//Float is a number that has decibles (Floating point numbers)
//String is "alpha numeric characters" which is what is displayed to players
// (;) means that it is the end of the sentence or command)
// Vector is the xyz of a world
// C# will give you a red line where it thinks the error is 
//Functions (Methods) are another building Blocks
// Homework Study Void/Int