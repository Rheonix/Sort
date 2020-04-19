using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This script updates the current score of the player as they are playing, keeping track of how many crates they have currectly sorted.
public class CurrentScoreManager : MonoBehaviour
{
    public static int score;        // Int for the player's score


    Text text;                      // Gets Text component.


    void Awake()
    {
        // Sets up reference to text component.
        text = GetComponent<Text>();

        // Resets the score at the beginning of the game.
        score = 0;
    }


    void Update()
    {
        // Sets up the displayed text to be "Current Score: ", followed by the value of the current score as it is updated.
        text.text = "Current Score: " + score;
    }
}
