using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeModeSpawnManager : MonoBehaviour {

    // Public array to hold the different types of crates to be spawned
    public GameObject[] cratesList;

    // Keeps track of the number of different crates that can be spawned
    int arraySize;

    // Timer for the spawn controller. In the final code I would need the time to shrink as the game goes on.
    public float spawnTime = 1.42f;

    // Grabs the health manager. In arcade mode I can set it to 1 at the start here
    HealthManager healthManager;

    // Used to access and check the current score
    GameControlManager gameControlManager;

    // Use this for initialization
    void Start () {
        arraySize = cratesList.Length;
        Random rnd = new Random();

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();
        gameControlManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameControlManager>();

        StartCoroutine(ArcadeModeSpawner());
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

    public IEnumerator ArcadeModeSpawner()
    {
        yield return new WaitForSeconds(0.001f);
        healthManager.LoseHealthNoFlash();
        healthManager.LoseHealthNoFlash();
        yield return new WaitForSeconds(2.55f);
        while (healthManager.health > 0)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
