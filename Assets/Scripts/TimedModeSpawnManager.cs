using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedModeSpawnManager : MonoBehaviour
{

    // Public array to hold the different types of crates to be spawned
    public GameObject[] cratesList;

    // Keeps track of the number of different crates that can be spawned
    int arraySize;

    // Timer for the spawn controller. In the final code I would need the time to shrink as the game goes on.
    public float spawnTime = 1.6f;

    public float spawnTimeDelay = 2.25f;

    public bool incorrectSort = false;

    public bool spawnIsDisabled = false;

    public float currentGameTime = 100f;

    // Grabs the health manager. In arcade mode I can set it to 1 at the start here
    HealthManager healthManager;

    // Used to access and check the current score
    GameControlManager gameControlManager;

    // Use this for initialization
    void Start()
    {
        arraySize = cratesList.Length;
        Random rnd = new Random();

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();
        gameControlManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameControlManager>();

        StartCoroutine(TimedModeSpawner());
        StartCoroutine(GameCountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        if (spawnIsDisabled == true)
        {
            return;
        }

        int crateIndex = Random.Range(0, cratesList.Length);

        Instantiate(cratesList[crateIndex], transform.position, transform.rotation);
    }

    public IEnumerator TimedModeSpawner()
    {
        yield return new WaitForSeconds(0.001f);
        healthManager.LoseHealthNoFlash();
        healthManager.LoseHealthNoFlash();
        yield return new WaitForSeconds(2.5f);
        while (currentGameTime > 0)
        {
            if(incorrectSort == true)
            {
                incorrectSort = false;
                yield return new WaitForSeconds(spawnTimeDelay);
            }
            else
            {
                Spawn();
                yield return new WaitForSeconds(spawnTime);
            }

        }
    }

    public IEnumerator GameCountdownTimer(float countdownValue = 30)
    {
        currentGameTime = countdownValue;

        while(currentGameTime > 0)
        {
            Debug.Log("Countdown: " + currentGameTime);
            yield return new WaitForSeconds(1.0f);
            currentGameTime--;
        }
    }
}
