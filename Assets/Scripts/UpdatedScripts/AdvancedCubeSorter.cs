using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Draft script for an improved, more efficent version of the sorting system
// This script goes onto each cube object, with each being tagged appropriately,
// and saved as a prefab.

// This is the sorter for classic mode, will need a different one for
// the other game modes
public class AdvancedCubeSorter : MonoBehaviour {

    int crateValue = 1;         // How  many points each crate is worth
    int currentScene;   // Current scene, used to restart the current game mode.


    GameObject crate;   // The crate object being sorted
    GameControlManager gameControlManager;
    HealthManager healthManager;

    TimedModeSpawnManager timedModeSpawnManager;


    // Use this for initialization
    void Start () {
        // sets the current scene value to the index of the currently loaded scene
        currentScene = SceneManager.GetActiveScene().buildIndex;
        gameControlManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameControlManager>();
        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();

        if(currentScene == 3)
        {
            timedModeSpawnManager = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<TimedModeSpawnManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    // maybe change name to CorrectSort, WrongSort, IncorrectSort
    // or SortCorrect, SortFailure
    void CorrectCube(GameObject cube)
    {
        Destroy(cube, 0.1f);
        gameControlManager.IncreaseScore();
        // call score manager to inc (have a game manager which manages score and health)
    }

    void WrongCube(GameObject cube)
    {
        if (currentScene == 3)
        {
            Destroy(cube, 0.1f);
            timedModeSpawnManager.incorrectSort = true;
        }
        else
        {
            Destroy(cube, 0.1f);
            healthManager.LoseHealth();
            // call health manager to lower health
        }

    }

    void HealthCube(GameObject cube)
    {
        Destroy(cube, 0.1f);
        gameControlManager.IncreaseScore();
        healthManager.GainHealth();
        // call health to increase
    }

    void HealthCubeFail(GameObject cube)
    {
        Destroy(cube, 0.1f);
        // dont lose health or get a point
    }


    void OnCollisionEnter(Collision collision)
    {
        if (tag == collision.gameObject.tag)
        {
            CorrectCube(collision.gameObject);
            GameControl.control.boxesSorted++;

            if(collision.gameObject.tag == "Square")
            {
                GameControl.control.squareBoxesSorted++;
            }
            else if(collision.gameObject.tag == "Circle")
            {
                GameControl.control.circleBoxesSorted++;
            }
            else if (collision.gameObject.tag == "Triangle")
            {
                GameControl.control.triangleBoxesSorted++;
            }
            else // increases trash in switch mode where trash may have their own bins
            {
                GameControl.control.trashBoxesSorted++;
            }
        }
        else if(tag == "Trash" && (collision.gameObject.tag == "Hollow Square"|| collision.gameObject.tag == "Diamond" || collision.gameObject.tag == "Rhombus" || collision.gameObject.tag == "Hollow Circle" || collision.gameObject.tag == "Octagon" || collision.gameObject.tag == "Oval" || collision.gameObject.tag == "Hollow Triangle" || collision.gameObject.tag == "Upside Down Triangle" || collision.gameObject.tag == "Right Triangle" || collision.gameObject.tag == "Star" || collision.gameObject.tag == "Pentagon" || collision.gameObject.tag == "Trapezoid" || collision.gameObject.tag == "Crescent"))
        {
            // increases trash and score in the normal mode where other cubes have their own tags
            CorrectCube(collision.gameObject);
            GameControl.control.boxesSorted++;
            GameControl.control.trashBoxesSorted++;
        }
        else if (collision.gameObject.tag == "Heart" && tag != "Trash")
        {
            HealthCube(collision.gameObject);
            GameControl.control.heartBoxesSorted++;
        }
        else if(collision.gameObject.tag == "Heart" && tag == "Trash")
        {
            HealthCubeFail(collision.gameObject);
        }
        else
        {
            WrongCube(collision.gameObject);
        }
    }
}
