using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


// use this script to load between secenes, keep track of the current score, and current health
// can also reference pause stuff maybe
public class GameControlManager : MonoBehaviour {

    AchievementManager achievementManager;

    // Score text objects in game will reference this script
    public int score;
    public int highScoreClassic;
    public int highScoreArcade;
    public int highScoreTimed;
    public int highScoreSwitch;

    int currentScene;

    public Text scoreText;
    public Text highScoreText;

    HealthManager healthManager;
    PauseManager pauseManager;

    Canvas gameOverCanvas;

    void Awake()
    {
        score = 0;

        if(currentScene != 0)
        {
            scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        }

        achievementManager = GetComponent<AchievementManager>();
        pauseManager = GameObject.FindGameObjectWithTag("pauseMan").GetComponent<PauseManager>();

        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>();
    }

    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        highScoreClassic = GameControl.control.classicHighScore;
        highScoreArcade = GameControl.control.arcadeHighScore;
        highScoreTimed = GameControl.control.timedHighScore;

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();

        if(currentScene == 1)
        {
            highScoreText.text = "High Score: " + GameControl.control.classicHighScore;
        }
        else if(currentScene == 2)
        {
            highScoreText.text = "High Score: " + GameControl.control.arcadeHighScore;
        }
    }

    // Update is called once per frame
    void Update() {
        /*
        if(currentScene != 0)
        {
            scoreText.text = "Score: " + score;

            if (score > highScoreClassic)
            {
                highScoreClassic = score;
                GameControl.control.classicHighScore = highScoreClassic;
            }

            highScoreText.text = "High Score: " + highScoreClassic;
        }  
        */

        if (currentScene == 1 && currentScene != 0)
        {
            scoreText.text = "Score: " + score;

            if (score > highScoreClassic)
            {
                highScoreClassic = score;
                GameControl.control.classicHighScore = highScoreClassic;
            }

            highScoreText.text = "High Score: " + highScoreClassic;
        }
        else if(currentScene == 2 && currentScene !=0)
        {
            scoreText.text = "Score: " + score;

            if (score > highScoreArcade)
            {
                highScoreArcade = score;
                GameControl.control.arcadeHighScore = highScoreArcade;
            }

            highScoreText.text = "High Score: " + highScoreArcade;
        }
        else if (currentScene == 3 && currentScene != 0)
        {
            scoreText.text = "Score: " + score;

            if (score > highScoreTimed)
            {
                highScoreTimed = score;
                GameControl.control.timedHighScore = highScoreTimed;
            }

            highScoreText.text = "High Score: " + highScoreTimed;
        }

    }



    /*
     *  Code below is for scene loading
     */
    
    // Loads main menu/ "Quits" out of current game mode
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        GameControl.control.Save();
        pauseManager.UnPause();
        //gameOverCanvas.enabled = false;
    }

    public void LoadNormalMode()
    {
        SceneManager.LoadScene(1);
        GameControl.control.gamesPlayed++;
        GameControl.control.classicGamesPlayed++;
        GameControl.control.Save();
        pauseManager.UnPause();
    }

    public void LoadArcadeMode()
    {
        SceneManager.LoadScene(2);
        GameControl.control.gamesPlayed++;
        GameControl.control.arcadeGamesPlayed++;
        // pauseManager.UnPaused();
    }

    public void LoadTimedMode()
    {
        SceneManager.LoadScene(3);
        GameControl.control.gamesPlayed++;
        // GameControl.control.timedGamesPlayed++;
        // pauseManager.UnPaused();
    }

    public void LoadSwitchMode()
    {
        SceneManager.LoadScene(2);
        GameControl.control.gamesPlayed++;
        GameControl.control.switchGamesPlayed++;
        // pauseManager.UnPaused();
    }

    public void RestartLevel()
    {
        pauseManager.UnPause();
        SceneManager.LoadScene(currentScene);
        GameControl.control.Save();
    }

    public void RoundEnd()
    {
        // bring up game end canvas
        // pause game
        // GameControl.control.Save();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        GameControl.control.Save();
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ResetSaveData()
    {
        GameControl.control.classicHighScore = 0;
        GameControl.control.arcadeHighScore = 0;
        GameControl.control.switchHighScore = 0;

        GameControl.control.gamesPlayed = 0;
        GameControl.control.classicGamesPlayed = 0;
        GameControl.control.arcadeGamesPlayed = 0;
        GameControl.control.switchGamesPlayed = 0;

        GameControl.control.boxesSorted = 0;
        GameControl.control.squareBoxesSorted = 0;
        GameControl.control.circleBoxesSorted = 0;
        GameControl.control.triangleBoxesSorted = 0;
        GameControl.control.trashBoxesSorted = 0;
        GameControl.control.heartBoxesSorted = 0;

        GameControl.control.hasVisitedAfroduck = false;
        GameControl.control.hasVisitedInstagram = false;
        GameControl.control.hasVisitedFacebook = false;

        GameControl.control.Save();
    }


    /*
     *  Code Below is for gameplay functions
     */
    
    public void IncreaseScore()
    {
        score++;
    }

}
