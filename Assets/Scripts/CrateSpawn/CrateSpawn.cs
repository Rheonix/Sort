using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawn : MonoBehaviour {
    // Public array to hold the different types of crates to be spawned
    public GameObject[] crates;

    // Keeps track of the number of different crates that can be spawned
    int arraySize;

    // Timer for the spawn controller. In the final code I would need the time to shrink as the game goes on.
    public float spawnTime = 5f;

    HealthManager healthManager;

    // Use this for initialization
    void Start ()
    {
        arraySize = crates.Length;
        Random rnd = new Random();

        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void Spawn()
    {
        if (healthManager.health <= 0)
        {
            return;
        }

        int crateIndex = Random.Range(0, crates.Length);

        Instantiate(crates[crateIndex], transform.position, transform.rotation);

    }
}
