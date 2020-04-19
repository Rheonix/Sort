using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    /* Script for keeping track of game data within
     * rounds of gameplay.
     */

    // array to keep track of all data within a round
    //public RoundData[] allRoundData;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject); // allows persistence of object

        //use below to load main menu, game starts at this scene.
        //LoadSceneManager.LoadScene["MenuScreen"];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
