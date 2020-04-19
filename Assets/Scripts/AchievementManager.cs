using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

    public GameObject[] achievementPanels;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // dont put here in final test, dont want to constantly update, only at the end of scenes
        // make achievement manager a separate object on the main menu. and make it static so other things can reference it
        // in other scenes
        CheckAllAchievements();
	}

    void CheckAllAchievements()
    {
        CheckGamesPlayed();
        CheckHighScores();
        CheckBoxesSorted();
        CheckSocialMedia();
    }

    void CheckGamesPlayed()
    {
        if(GameControl.control.gamesPlayed < 50 && GameControl.control.gamesPlayed >= 10)
        {
            // show the appropriate achievement
            // actually set the rank cuz then that can be used for other things outside of the picture, like credit for unlocks
            EnableBronze(achievementPanels[0]);
            achievementPanels[0].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 50 games";
        }
        else if(GameControl.control.gamesPlayed < 100 && GameControl.control.gamesPlayed  >= 50)
        {
            EnableSilver(achievementPanels[0]);
            achievementPanels[0].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 100 games";
        }
        else if (GameControl.control.gamesPlayed >= 100)
        {
            EnableGold(achievementPanels[0]);
        }

        // -----------------------------------------------

        if (GameControl.control.classicGamesPlayed < 50 && GameControl.control.classicGamesPlayed >= 10)
        {
            EnableBronze(achievementPanels[1]);
            achievementPanels[1].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 50 classic games";
        }
        else if (GameControl.control.classicGamesPlayed < 100 && GameControl.control.classicGamesPlayed >= 50)
        {
            EnableSilver(achievementPanels[1]);
            achievementPanels[1].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 100 classic games";
        }
        else if (GameControl.control.classicGamesPlayed >= 100)
        {
            EnableGold(achievementPanels[1]);
        }

        // -----------------------------------------------

        if (GameControl.control.arcadeGamesPlayed < 50 && GameControl.control.arcadeGamesPlayed >= 10)
        {
            EnableBronze(achievementPanels[2]);
            achievementPanels[2].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 50 arcade games";
        }
        else if (GameControl.control.arcadeGamesPlayed < 100 && GameControl.control.arcadeGamesPlayed >= 50)
        {
            EnableSilver(achievementPanels[2]);
            achievementPanels[2].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 100 classic games";
        }
        else if (GameControl.control.arcadeGamesPlayed >= 100)
        {
            EnableGold(achievementPanels[2]);
        }

        // -----------------------------------------------

        if (GameControl.control.switchGamesPlayed < 50 && GameControl.control.switchGamesPlayed >= 10)
        {
            EnableBronze(achievementPanels[3]);
            achievementPanels[3].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 50 switch games";
        }
        else if (GameControl.control.switchGamesPlayed < 100 && GameControl.control.switchGamesPlayed >= 50)
        {
            EnableSilver(achievementPanels[3]);
            achievementPanels[3].transform.Find("Ach_Description").GetComponent<Text>().text = "Play 100 switch games";
        }
        else if (GameControl.control.switchGamesPlayed >= 100)
        {
            EnableGold(achievementPanels[3]);
        }

        if (GameControl.control.classicGamesPlayed >= 1 && GameControl.control.arcadeGamesPlayed >= 1 && GameControl.control.switchGamesPlayed >= 1)
        {
            EnableGold(achievementPanels[4]);
        }
    }

    void CheckBoxesSorted()
    {
        if (GameControl.control.boxesSorted < 250 && GameControl.control.boxesSorted >= 100)
        {
            EnableBronze(achievementPanels[8]);
            achievementPanels[8].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 250 boxes";
        }
        else if (GameControl.control.boxesSorted < 500 && GameControl.control.boxesSorted >= 250)
        {
            EnableSilver(achievementPanels[8]);
            achievementPanels[8].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 500 boxes";
        }
        else if (GameControl.control.boxesSorted >= 500)
        {
            EnableGold(achievementPanels[8]);
        }

        if (GameControl.control.squareBoxesSorted < 100 && GameControl.control.squareBoxesSorted >= 50)
        {
            EnableBronze(achievementPanels[9]);
            achievementPanels[9].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 100 square boxes";
        }
        else if (GameControl.control.squareBoxesSorted < 250 && GameControl.control.squareBoxesSorted >= 100)
        {
            EnableSilver(achievementPanels[9]);
            achievementPanels[9].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 250 square boxes";
        }
        else if (GameControl.control.squareBoxesSorted >= 250)
        {
            EnableGold(achievementPanels[9]);
        }

        if (GameControl.control.circleBoxesSorted < 100 && GameControl.control.circleBoxesSorted >= 50)
        {
            EnableBronze(achievementPanels[10]);
            achievementPanels[10].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 100 circle boxes";
        }
        else if (GameControl.control.circleBoxesSorted < 250 && GameControl.control.circleBoxesSorted >= 100)
        {
            EnableSilver(achievementPanels[10]);
            achievementPanels[10].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 250 circle boxes";
        }
        else if (GameControl.control.circleBoxesSorted >= 250)
        {
            EnableGold(achievementPanels[10]);
        }

        if (GameControl.control.triangleBoxesSorted < 100 && GameControl.control.triangleBoxesSorted >= 50)
        {
            EnableBronze(achievementPanels[11]);
            achievementPanels[11].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 100 triangle boxes";
        }
        else if (GameControl.control.triangleBoxesSorted < 250 && GameControl.control.triangleBoxesSorted >= 100)
        {
            EnableSilver(achievementPanels[11]);
            achievementPanels[11].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 250 triangle boxes";
        }
        else if (GameControl.control.triangleBoxesSorted >= 250)
        {
            EnableGold(achievementPanels[11]);
        }

        if (GameControl.control.heartBoxesSorted < 50 && GameControl.control.heartBoxesSorted >= 10)
        {
            EnableBronze(achievementPanels[12]);
            achievementPanels[10].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 50 heart boxes";
        }
        else if (GameControl.control.heartBoxesSorted < 100 && GameControl.control.heartBoxesSorted >= 50)
        {
            EnableSilver(achievementPanels[12]);
            achievementPanels[12].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 100 heart boxes";
        }
        else if (GameControl.control.heartBoxesSorted >= 100)
        {
            EnableGold(achievementPanels[12]);
        }

        if (GameControl.control.trashBoxesSorted < 500 && GameControl.control.trashBoxesSorted >= 100)
        {
            EnableBronze(achievementPanels[13]);
            achievementPanels[13].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 500 trash boxes";
        }
        else if (GameControl.control.trashBoxesSorted < 1000 && GameControl.control.trashBoxesSorted >= 500)
        {
            EnableSilver(achievementPanels[13]);
            achievementPanels[13].transform.Find("Ach_Description").GetComponent<Text>().text = "Sort 1000 trash boxes";
        }
        else if (GameControl.control.trashBoxesSorted >= 1000)
        {
            EnableGold(achievementPanels[13]);
        }
    }

    void CheckHighScores()
    {
        if (GameControl.control.classicHighScore < 100 && GameControl.control.classicHighScore >= 50)
        {
            EnableBronze(achievementPanels[5]);
            achievementPanels[5].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 100 in classic mode";
        }
        else if (GameControl.control.classicHighScore < 150 && GameControl.control.classicHighScore >= 100)
        {
            EnableSilver(achievementPanels[5]);
            achievementPanels[5].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 150 in classic mode";
        }
        else if (GameControl.control.classicHighScore >= 150)
        {
            EnableGold(achievementPanels[5]);
        }

        if (GameControl.control.arcadeHighScore < 100 && GameControl.control.arcadeHighScore >= 50)
        {
            EnableBronze(achievementPanels[6]);
            achievementPanels[6].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 100 in arcade mode";
        }
        else if (GameControl.control.arcadeHighScore < 150 && GameControl.control.arcadeHighScore >= 100)
        {
            EnableSilver(achievementPanels[6]);
            achievementPanels[6].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 150 in arcade mode";
        }
        else if (GameControl.control.arcadeHighScore >= 150)
        {
            EnableGold(achievementPanels[6]);
        }

        if (GameControl.control.switchHighScore < 100 && GameControl.control.switchHighScore >= 50)
        {
            EnableBronze(achievementPanels[7]);
            achievementPanels[7].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 100 in switch mode";
        }
        else if (GameControl.control.switchHighScore < 150 && GameControl.control.switchHighScore >= 100)
        {
            EnableSilver(achievementPanels[7]);
            achievementPanels[7].transform.Find("Ach_Description").GetComponent<Text>().text = "Score 150 in switch mode";
        }
        else if (GameControl.control.switchHighScore >= 150)
        {
            EnableGold(achievementPanels[7]);
        }
    }

    void CheckSocialMedia()
    {
        if(GameControl.control.hasVisitedAfroduck == true && GameControl.control.hasVisitedFacebook == true && GameControl.control.hasVisitedInstagram == true)
        {
            EnableGold(achievementPanels[14]);
        }
    }

    void CheckPerfection()
    {
        int counter = 0;

        for (int i = 0; i < 16; i++)
        {
            if(achievementPanels[i].transform.Find("GoldTrophy").GetComponent<Image>().enabled == true)
            {
                counter++;
            }
        }

        if (counter == 16)
        {
            EnableGold(achievementPanels[15]);
        }
    }
                    

    void EnableBronze(GameObject panel)
    {
        panel.transform.Find("BronzeTrophy").GetComponent<Image>().enabled = true;

        panel.transform.Find("SilverTrophy").GetComponent<Image>().enabled = false;
        panel.transform.Find("GoldTrophy").GetComponent<Image>().enabled = false;
    }

    void EnableSilver(GameObject panel)
    {
        panel.transform.Find("SilverTrophy").GetComponent<Image>().enabled = true;

        panel.transform.Find("BronzeTrophy").GetComponent<Image>().enabled = false;
        panel.transform.Find("GoldTrophy").GetComponent<Image>().enabled = false;
    }

    void EnableGold(GameObject panel)
    {
        panel.transform.Find("GoldTrophy").GetComponent<Image>().enabled = true;

        panel.transform.Find("BronzeTrophy").GetComponent<Image>().enabled = false;
        panel.transform.Find("SilverTrophy").GetComponent<Image>().enabled = false;
    }

}
