using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    int currentScene;

    HealthManager healthManager;
    PauseManager pauseManager;

    TimedModeSpawnManager timedModeSpawnManager;

    Canvas canvas;

    // Use this for initialization
    void Start ()
    {
        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();
        canvas = GetComponent<Canvas>();
        pauseManager = GameObject.FindGameObjectWithTag("pauseMan").GetComponent<PauseManager>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 3)
        {
            timedModeSpawnManager = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<TimedModeSpawnManager>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (healthManager.health == 0 || timedModeSpawnManager.currentGameTime == 0)
        {
            canvas.enabled = !canvas.enabled;
            healthManager.health = -1;
            timedModeSpawnManager.currentGameTime = -1;
            GameControl.control.Save();
            pauseManager.Pause();
        }
    }
}
