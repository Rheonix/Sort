using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This script updates the current score of the player as they are playing, keeping track of how many crates they have currectly sorted.
public class HighScoreManager : MonoBehaviour
{
    public static int highScore = 0;        // Int for the player's high score

    Text text;                              // Gets Text component.

    CurrentScoreManager currentScoreManager;

    void Awake()
    {
        // Sets up reference to text component.
        text = GetComponent<Text>();

        //currentScoreManager = GameObject.FindGameObjectWithTag("score").GetComponent<CurrentScoreManager>();
    }


    void Update()
    {
        // Sets up the displayed text to be "Current Score: ", followed by the value of the current score as it is updated.
        text.text = "High Score: " + highScore;

        if (CurrentScoreManager.score > highScore)
        {
            highScore = CurrentScoreManager.score;
            text.text = "" + CurrentScoreManager.score;

            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
}
