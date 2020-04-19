using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    PauseManager pauseManager;
    // Use this for initialization
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to restart a current game
    public void restartGame()
    {
        SceneManager.LoadScene("prototypeGameLevel");
        pauseManager.Pause();
    }

    // Function to start a new game from main menu
    public void startNewGame()
    {
        SceneManager.LoadScene("prototypeGameLevel");
    }
}
