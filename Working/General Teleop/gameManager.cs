using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class gameManager : MonoBehaviour
{
    //Assignables
    SuperBasicControllerManager controllerManager;
    //Variables

    //Controler state
    public bool noControllerOne = false;
    public bool noControllerTwo = false;

    //Sim state
    public bool simulationRunning = false;
    public bool simulationStopped = true;
    public bool simulationPaused = false;
    public bool stoppedForController = false;
    public bool endgame = false;
    public bool autonomous = false;
    public bool timerEnabled = false;



    //Starts before start function


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (simulationRunning == false)//remove if no work
        {
            //UnityEditor.EditorApplication.isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            //UnityEditor.EditorApplication.isPaused = false;
            Time.timeScale = 1;
        }


    

        

        if (simulationStopped == true)
        {
            simulationRunning = false;
            simulationPaused = false;
        }

        if (simulationPaused == true)
        {
            simulationRunning = false;
        }

        if (simulationRunning)//remove if no work
        {
            simulationPaused = false;
            simulationStopped = false;
        }
    }

        public void Pause()
        {
           simulationPaused = true;
        }

}
