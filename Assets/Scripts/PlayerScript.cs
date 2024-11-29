using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
 
    private Rigidbody rb;


    private int pickupCount;
    private int totalPickups;
    private float pickupChunk;

    //Timer
    private Timer timer;

    //Game Over Screen
    public bool gameOver = false;

    [Header("UI")]
    public TMP_Text pickupText;
    public Image pickupImage;

    public GameObject winPanel;

    public TMP_Text HealthText;

    public TMP_Text timerText;
    public TMP_Text winTimeText;
    
    public GameObject inGamePanel;

    public GameObject losePanel;

    private PlayerController playerController;

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

        //Pause Script
        Time.timeScale = 1;

        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.currentTime.ToString("F2");
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
        playerController.gameOver = true;

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