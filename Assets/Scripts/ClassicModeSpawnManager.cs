using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicModeSpawnManager : MonoBehaviour {

    // Public array to hold the different types of crates to be spawned
    public GameObject[] cratesList;

    // Holds the healing crate object
    public GameObject healingCrate;

    // Ensures at least 50 crates have been spawned since last healing crate, preventing repeated healing crates
    int crateCounter;

    // Keeps track of the number of different crates that can be spawned
    int arraySize;

    // Timer for the spawn controller. In the final code I would need the time to shrink as the game goes on.
    public float spawnTime = 4f;

    // Grabs the health manager. In arcade mode I can set it to 1 at the start here
    HealthManager healthManager;

    // Used to access and check the current score
    GameControlManager gameControlManager;

    // Use this for initialization
    void Start () {
        arraySize = cratesList.Length;
        Random rnd = new Random();
        crateCounter = 0;

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();
        gameControlManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameControlManager>();

        StartCoroutine(ClassicModeSpawner());
        StartCoroutine(DifficultyIncreaseTimer());
 
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Spawn()
    {
        if (healthManager.health <= 0)
        {
            return;
        }

        int crateIndex = Random.Range(0, cratesList.Length);

        Instantiate(cratesList[crateIndex], transform.position, transform.rotation);
    }

    void SpawnHeal()
    {
        if(healthManager.health <= 0)
        {
            return;
        }

        Instantiate(healingCrate, transform.position, Quaternion.Euler(0, -90, 0));
    }

    public IEnumerator ClassicModeSpawner()
    {
        yield return new WaitForSeconds(2.6f);
        while (healthManager.health > 0)
        {

            if(gameControlManager.score % 50 == 0 && crateCounter >= 50)
            {
                SpawnHeal();
                crateCounter = 0;
                yield return new WaitForSeconds(spawnTime);
            }
            else
            {
                Spawn();
                yield return new WaitForSeconds(spawnTime);
                crateCounter++;
            }

        }


    }

    public IEnumerator DifficultyIncreaseTimer()
    {   
        yield return new WaitForSeconds(10f);
        while(spawnTime > 0.75f)
        {
            spawnTime = spawnTime - 0.25f;
            yield return new WaitForSeconds(15f);
        }      
    }
    
}
