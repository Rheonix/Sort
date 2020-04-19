using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class MenusManager : MonoBehaviour
{

    public Canvas mainCanvas;
    public Canvas gameModeCanvas;
    public Canvas achievementsCanvas;
    public Canvas settingsCanvas;
    public Canvas tutorialCanvas;


    public void OpenGameModes()
    {
        gameModeCanvas.enabled = !gameModeCanvas.enabled;
        mainCanvas.enabled = !mainCanvas.enabled;
    }

    public void OpenAchievements()
    {
        achievementsCanvas.enabled = !achievementsCanvas.enabled;
        mainCanvas.enabled = !mainCanvas.enabled;
    }

    public void OpenTutorials()
    {
        tutorialCanvas.enabled = !tutorialCanvas.enabled;
        mainCanvas.enabled = !mainCanvas.enabled;
    }

    public void OpenSettings()
    {
        settingsCanvas.enabled = !settingsCanvas.enabled;
        mainCanvas.enabled = !mainCanvas.enabled;
    }

    public void OpenMainMenu()
    {
        gameModeCanvas.enabled = false;
        achievementsCanvas.enabled = false;
        settingsCanvas.enabled = false;
        mainCanvas.enabled = !mainCanvas.enabled;
    }
}
