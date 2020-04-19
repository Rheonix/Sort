using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateMechanics : MonoBehaviour {

    // The speed at which the crates move
    public float speed = 8f;

    // This bool keeps track of whether or not crate can be moved yet
    bool crateActive = false;

    // This bool keeps track of whether or not crate has already moved, disabling movement if it has.
    bool crateDone = false;

    int currentScene;

    Vector3 movement;
    Rigidbody crateRigidbody;
    GameObject landingPad;   // used to represent the pad the crates land on

    HealthManager healthManager;

    TimedModeSpawnManager timedModeSpawnManager;

    // Use this for initialization
    void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("healthPanel").GetComponent<HealthManager>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 3)
        {
            timedModeSpawnManager = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<TimedModeSpawnManager>();
        }
    }

        void Awake()
    {
        landingPad = GameObject.FindGameObjectWithTag("landing pad");
        crateRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crateRigidbody.IsSleeping())
        {
            crateRigidbody.WakeUp();
        }

        if (Input.GetKeyDown("w") && crateActive == true && crateDone == false)
        {
            MoveUp();
            crateDone = true;
        }
        else if (Input.GetKeyDown("s") && crateActive == true && crateDone == false)
        {
            MoveDown();
            crateDone = true;
        }
        else if (Input.GetKeyDown("a") && crateActive == true && crateDone == false)
        {
            MoveLeft();
            crateDone = true;
        }
        else if (Input.GetKeyDown("d") && crateActive == true && crateDone == false)
        {
            MoveRight();
            crateDone = true;
        }
    }

    /*
    void FixedUpdate()
    {
        if (Input.GetKeyDown("w") && crateActive == true && crateDone == false)
        {
            MoveUp();
            crateDone = true;
        }
        else if (Input.GetKeyDown("s") && crateActive == true && crateDone == false)
        {
            MoveDown();
            crateDone = true;
        }
        else if (Input.GetKeyDown("a") && crateActive == true && crateDone == false)
        {
            MoveLeft();
            crateDone = true;
        }
        else if (Input.GetKeyDown("d") && crateActive == true && crateDone == false)
        {
            MoveRight();
            crateDone = true;
        }
    }
    */

    // Function to move crates downward
    void MoveDown()
    {
        //GetComponent<Rigidbody>().velocity = -transform.forward * speed;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2) * speed;
        crateActive = false;
    }

    // Function to move crates upward
    void MoveUp()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,2) * speed;
        crateActive = false;
    }

    // Function to move crates left
    void MoveLeft()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-2,0,0) * speed;
        crateActive = false;
    }

    // Function to move crates right
    void MoveRight()
    {
        //GetComponent<Rigidbody>().velocity = transform.right * speed;
        GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0) * speed;
        crateActive = false;
    }

    // The trigger functions enable the movement of a crate when it hits the floor, change first one to collision, keep second as trigger probably
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == landingPad)
        {
            crateActive = true;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8 && crateActive == true)
        {
            Destroy(gameObject);

            if(currentScene == 3)
            {
                timedModeSpawnManager.incorrectSort = true;
            }
            else
            {
                healthManager.LoseHealth();
            }

        }
    }

}
