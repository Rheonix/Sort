using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary; // Makes files more secure than player prefs
using System.IO; // used to create save and load files

// possibly try to consolidate music manager/change volume,
// and combine it with gamecontroller to make it one
// unified object
// save the position of the slider as well

public class GameControl : MonoBehaviour {

    // Class that saves data from across the game,
    // capable of carrying the data across scenes.

    // allows object to be modifed and accessed
    // without having to search for a reference for it
    public static GameControl control;

    // Data for player scores
    public int classicHighScore = 0;
    public int arcadeHighScore = 0;
    public int timedHighScore = 0;
    public int switchHighScore = 0;

    // Data for achievement related variables
    public int gamesPlayed = 0;
    //public int gamesPlayedRank = 0;
    public int classicGamesPlayed = 0;
    public int arcadeGamesPlayed = 0;
    public int switchGamesPlayed = 0;
    public int boxesSorted = 0;
    //public int boxesSortedRank = 0;
    public int squareBoxesSorted = 0;
    //public int squareBoxesSortedRank = 0;
    public int circleBoxesSorted = 0;
    //public int circleBoxesSortedRank = 0;
    public int triangleBoxesSorted = 0;
    //public int triangleBoxesSortedRank = 0;
    public int trashBoxesSorted = 0;
    //public int trashBoxesSortedRank = 0;
    public int heartBoxesSorted = 0;
    //public int heartBoxesSortedRank = 0;
    public bool hasVisitedAfroduck = false;
    public bool hasVisitedInstagram = false;
    public bool hasVisitedFacebook = false;

    // Data for game options
    public float musicVolume;
    public float sfxVolume;

    //public float musicVolumeSliderPosition;
    // public float sfxVolumeSliderPosition;

    // Data for player achievement progress
    // include ints for progress, as well
    // as booleans for medals earned.

    // Sets control if not already created, 
    // otherwise destroys any new game control.
    void Awake ()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }

        Load();
	}

    // create a file to push data to
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); // works on pc, ios, and android

        PlayerGameData data = new PlayerGameData();
        data.classicHighScore = classicHighScore;
        data.arcadeHighScore = arcadeHighScore;
        data.timedHighScore = timedHighScore;
        data.switchHighScore = switchHighScore;

        data.gamesPlayed = gamesPlayed;
        //data.gamesPlayedRank = gamesPlayedRank;
        data.classicGamesPlayed = classicGamesPlayed;
        data.arcadeGamesPlayed = arcadeGamesPlayed;
        data.switchGamesPlayed = switchGamesPlayed;
        data.boxesSorted = boxesSorted;
        //data.boxesSortedRank = boxesSortedRank;
        data.squareBoxesSorted = squareBoxesSorted;
        //data.squareBoxesSortedRank = squareBoxesSortedRank;
        data.circleBoxesSorted = circleBoxesSorted;
        //data.circleBoxesSortedRank = circleBoxesSortedRank;
        data.triangleBoxesSorted = triangleBoxesSorted;
        //data.triangleBoxesSortedRank = triangleBoxesSortedRank;
        data.trashBoxesSorted = trashBoxesSorted;
        //data.trashBoxesSortedRank = trashBoxesSortedRank;
        data.heartBoxesSorted = heartBoxesSorted;
        //data.heartBoxesSortedRank = heartBoxesSortedRank;
        data.hasVisitedAfroduck = hasVisitedAfroduck;
        data.hasVisitedInstagram = hasVisitedInstagram;
        data.hasVisitedFacebook = hasVisitedFacebook;

        data.musicVolume = musicVolume;
        //data.musicVolumeSliderPosition = musicVolumeSliderPosition;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerGameData data = (PlayerGameData)bf.Deserialize(file);
            file.Close();

            classicHighScore = data.classicHighScore;
            arcadeHighScore = data.arcadeHighScore;
            timedHighScore = data.timedHighScore;
            switchHighScore = data.switchHighScore;

            gamesPlayed = data.gamesPlayed;
            classicGamesPlayed = data.classicGamesPlayed;
            switchGamesPlayed = data.switchGamesPlayed;
            boxesSorted = data.boxesSorted;
            squareBoxesSorted = data.squareBoxesSorted;
            circleBoxesSorted = data.circleBoxesSorted;
            triangleBoxesSorted = data.triangleBoxesSorted;
            trashBoxesSorted = data.trashBoxesSorted;
            heartBoxesSorted = data.heartBoxesSorted;
            hasVisitedAfroduck = data.hasVisitedAfroduck;
            hasVisitedInstagram = data.hasVisitedInstagram;
            hasVisitedFacebook = data.hasVisitedFacebook;

            musicVolume = data.musicVolume;
            //musicVolumeSliderPosition = data.musicVolumeSliderPosition;

        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(10,10,200,50), "Sound: " + musicVolume + "Games Played: " + classicGamesPlayed);
    }
}

[Serializable]
class PlayerGameData
{
    // This class will keep track of game settings, player scores, and data related to achievements

    // Data for player scores
    public int classicHighScore; // classic game mode, difficult builds up
    public int arcadeHighScore; // speed starts high, only have 1 life
    public int timedHighScore;
    public int switchHighScore; // items to sort switch every 10-15 seconds


    // Data for achievement related variables
    public int classicHighScoreRank;
    public int switchHighScoreRank;

    public int gamesPlayed; // number of total games in any game mode
    public int gamesPlayedRank;

    // public float timePlayed;
    // public int timePlayedRank;

    public int classicGamesPlayed; // number of classic games played
    public int arcadeGamesPlayed;
    public int switchGamesPlayed; // number of switch games played

    public int boxesSorted;
    public int boxesSortedRank; // = 0,1,2, or 3 depending on no, bronze, silver, or gold achievement

    public int squareBoxesSorted;
    public int squareBoxesSortedRank;

    public int circleBoxesSorted;
    public int circleBoxesSortedRank;

    public int triangleBoxesSorted;
    public int triangleBoxesSortedRank;

    public int trashBoxesSorted;
    public int trashBoxesSortedRank;

    public int heartBoxesSorted;
    public int heartBoxesSortedRank;

    public bool hasVisitedAfroduck; // checks to see if afroduck button has been clicked
    public bool hasVisitedInstagram; // checks if page has been visited
    public bool hasVisitedFacebook; // checks to see if fb page has been visited

    // Data for game options/settings
    public float musicVolume;
    //public float sfxVolume;

    //public float musicVolumeSliderPosition;
}