using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress {

    /* Class for storing basic data for the game: sound options,
     * high scores, and achievement progress using Player Prefs.
     * Typically you do not want to use player prefs to store
     * data as player prefs is human readable and easy to edit.
     * In addition, it is inefficient for storinglarge amounts 
     * of data. However, for a simple 1 player game like this
     * without large amounts of data it is fine to use. In
     * normal situations you would only use player prefs for
     * settings data such as sound volume, player controls, etc.
     */

    // Data for player scores
    public int classicHighScore;
    public int arcadeHighScore;
    public int timedHighScore;
    public int switchHighScore;

    // Data for game options
    public float musicVolume;
    public float sfxVolume;

    // Data for player achievement progress
    // include ints for progress, as well
    // as booleans for medals earned.
}
