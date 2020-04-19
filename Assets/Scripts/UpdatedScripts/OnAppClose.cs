using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script for saving game data when app is suspended or quit
public class OnAppClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
        OnApplicationQuit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnApplicationQuit()
    {
        GameControl.control.Save();
    }

    /*
    void OnApplicationPause()
    {
        GameControl.control.Save();
    }

    void OnApplicationFocus()
    {
        GameControl.control.Save();
    }
    */
}
