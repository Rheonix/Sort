using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerCountdown : MonoBehaviour
{
    public int timeLeft = 30; //Seconds Overall
    public Text countdown; //UI Text Object

    void Start()
    {
        countdown = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();

        StartCoroutine(LoseTime());
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("Timer: " + timeLeft); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}