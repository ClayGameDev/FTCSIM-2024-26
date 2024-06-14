using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class timer : MonoBehaviour
{
    public float timeAmount = 150f;
    public TextMeshProUGUI timeText;
    

    public  gameManager gameManager;
    // Start is called before the first frame update
    
    



    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>(); ;

        if (gameManager.timerEnabled == true)
        {
            gameObject.SetActive(true);
   
        }

        if (gameManager.timerEnabled == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.simulationPaused == false && gameManager.stoppedForController == false)
        { 
            if (gameManager.timerEnabled == true && timeAmount > 0 && gameManager.simulationRunning)
            {
                timeAmount -= Time.deltaTime;
            }
            else
            {
                timeAmount = 0;
            }
        }   
        displayTime(timeAmount);
    }

    void displayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        if (timeAmount <= 0)
        {
            gameManager.simulationStopped = true;
        }

        if (timeAmount <= 30)
        {
            gameManager.endgame = true;
        }

    }

}
