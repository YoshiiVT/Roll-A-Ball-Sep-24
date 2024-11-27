using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 10;
    //public float jumpSpeed = 1.0f;
    private Rigidbody rb;


    private int pickupCount;
    private int totalPickups;
    private float pickupChunk;

    //Timer
    private Timer timer;

    //Game Over Screen
    public bool gameOver = false;

    //Reset Zone Variables
    GameObject resetPoint;
    bool resetting = false;
    Color originalcolour;

    [Header("UI")]
    public TMP_Text pickupText;
    public TMP_Text timerText;
    public Image pickupImage;
    public GameObject winPanel;
    public TMP_Text winTimeText;
    public GameObject inGamePanel;

    public GameObject losePanel;

    void Start()
    {
        //Gets the rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        //Gets the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Assign the toal amount of pickups
        totalPickups = pickupCount;
        //Set the pickup Image fill amount to 0
        pickupImage.fillAmount = 0;
        //work out the pickup chunk fill amount
        pickupChunk = 1.0f / totalPickups;
        //Run the CheckPickups Function
        CheckPickups();
        //Gets the timer object
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();

        //Turn off our win panel
        winPanel.SetActive(false);

        losePanel.SetActive(false);

        //Reset Zone Code
        resetPoint = GameObject.Find("Reset Point");
        originalcolour = GetComponent<Renderer>().material.color;

        //Pause Script
        Time.timeScale = 1;
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.currentTime.ToString("F2");
    }
    private void FixedUpdate()
    {
        if (gameOver == true)
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
        if (resetting)
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            //Destroy the collided Object
            Destroy(other.gameObject);
            //Decrement the pickup count
            pickupCount--;
            // increase the fill amount of our pickup image
            pickupImage.fillAmount = pickupImage.fillAmount + pickupChunk;
            // Run the Check Pickups Function
            CheckPickups();

        }
    }
    private void CheckPickups()
    {

        //Do text stuff
        print("Pickups left: " + pickupCount);
        pickupText.text = "Pickups left: " + pickupCount.ToString();
        if (pickupCount == 0)
        {
            Wingame();
        }
    }

    private void Wingame()
    {
        //Sets game over to true
        gameOver = true;

        //Stop the timer
        timer.StopTimer();
        print("SUGOI!! You win! Your time was: " + timer.GetTime().ToString("F2") + " Seconds");

        //Display the timer on our win time text
        winTimeText.text = "Time: " + timer.currentTime.ToString("F2");

        //Turn on our win panel
        winPanel.SetActive(true);

        //Turn off our in game panel
        inGamePanel.SetActive(false);

        //Stop the ball from rolling
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }
    public void LoseGame()
    {
        gameOver = true;

        timer.StopTimer();

        losePanel.SetActive(true);

        inGamePanel.SetActive(false);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //Temporary restart function
    public void ResetGame()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }
    public IEnumerator ResetPlayer() 
    {
        resetting = true;
        GetComponent <Renderer>().material.color = Color.black;
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