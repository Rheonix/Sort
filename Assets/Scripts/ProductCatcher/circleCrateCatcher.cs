using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This script updates the current score of the player as they are playing, keeping track of how many crates they have currectly sorted.
public class circleCrateCatcher : MonoBehaviour
{
    public static int score;        // Int for the player's score

    GameObject scoreDisplay;
    GameObject crate; // The crate interacting with the catcher
    CrateType crateType;

    Text text;                      // Gets Text component.

    Text scoreText;


    void Awake()
    {

        scoreDisplay = GameObject.FindGameObjectWithTag("score");
        scoreText = scoreDisplay.GetComponent<Text>();

        crate = GameObject.FindGameObjectWithTag("crate");
        crateType = crate.GetComponent<CrateType>();

    }


    void Update()
    {
        // Sets up the displayed text to be "Current Score: ", followed by the value of the current score as it is updated.
        scoreText.text = "Current Score: " + score;
    }

    // The trigger functions enable the movement of a crate when it hits the floor
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == crate)
        {
            //if(crate.crateType.)
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == crate)
        {
            //crateActive = false;
        }
    }
}
