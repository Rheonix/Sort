using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateMovement : MonoBehaviour {

    // The speed at which the crates move
    public float speed = 8f;

    Vector3 movingRight;


    // This bool keeps track of whether or not crate can be moved yet
    bool crateActive = false;

    // This bool keeps track of whether or not crate has already moved, disabling movement if it has.
    bool crateDone = false;

    //int floorMask;
    Vector3 movement;
    Rigidbody crateRigidbody;
    GameObject landingPad;   // used to represent the pad the crates land on

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        landingPad = GameObject.FindGameObjectWithTag("landing pad"); //replace this with player = whatever the other collider is? that way i can use this for multiple characters
        crateRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(crateRigidbody.IsSleeping())
        {
            crateRigidbody.WakeUp();
        }
    }

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
        else if (Input.GetKeyDown("d")  && crateActive == true && crateDone == false)
        {
            MoveRight();
            crateDone = true;
        }
    }

    // Function to move crates downward
    void MoveDown()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }

    // Function to move crates upward
    void MoveUp()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Function to move crates left
    void MoveLeft()
    {
        GetComponent<Rigidbody>().velocity = -transform.right * speed;
    }

    // Function to move crates right
    void MoveRight()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }

    // The trigger functions enable the movement of a crate when it hits the floor
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == landingPad)
        {
            crateActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == landingPad)
        {
            crateActive = false;
        }
    }
}
