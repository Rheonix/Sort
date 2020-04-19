using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This script will be in charge of the destruction of the different product crates.
 * This script will first get the type of this crate from the CrateType script.
 * Then it will get the script from the crate catcher. Each crate catcher will
 * have a variable keeping track of what product it was meant for.
 * If both the crate and catcher have the same product type then a point
 * will be added to the total score for the game.*/
public class crateDestroy : MonoBehaviour {

    int crateValue = 1;         // How  many points each crate is worth
    GameObject scoreDisplay;
    GameObject crate;           // The crate interacting with the catcher
    GameObject circleCatcher;
    GameObject squareCatcher;
    GameObject triangleCatcher;
    GameObject trashCatcher;

    CurrentScoreManager currentScoreManager;
    HealthManager healthManager;
    CrateType crateType;
    Text text;                      // Gets Text component.
    Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        circleCatcher = GameObject.FindGameObjectWithTag("circle_catcher");
        squareCatcher = GameObject.FindGameObjectWithTag("square_catcher");
        triangleCatcher = GameObject.FindGameObjectWithTag("triangle_catcher");
        trashCatcher = GameObject.FindGameObjectWithTag("trash_catcher");

        crateType = GetComponent<CrateType>();

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();

    }

    // Update is called once per frame
    void Update() {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == circleCatcher)
        {
            if (crateType.isCircle == true)
            {
                CurrentScoreManager.score++;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                healthManager.LoseHealth();
                Destroy(gameObject, 0.1f);
            }
        }

        if (other.gameObject == squareCatcher)
        {
            if (crateType.isSquare == true)
            {
                CurrentScoreManager.score++;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                healthManager.LoseHealth();
                Destroy(gameObject, 0.1f);
            }
        }

        if (other.gameObject == triangleCatcher)
        {
            if (crateType.isTriangle == true)
            {
                CurrentScoreManager.score++;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                healthManager.LoseHealth();
                Destroy(gameObject, 0.1f);
            }
        }

        if (other.gameObject == trashCatcher)
        {
            if (crateType.isTrash == true)
            {
                CurrentScoreManager.score++;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                healthManager.LoseHealth();
                Destroy(gameObject, 0.1f);
            }
        }
    }


}
