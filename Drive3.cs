using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drive3 : MonoBehaviour
{
    public Gamepad[] gamepads;
    public float Speed;

    public Rigidbody CoreRB;
    public GameObject frontRightWheel;
    public GameObject backRightWheel;
    public GameObject frontLeftWheel;
    public GameObject backLeftWheel;
    public gameManager gameManager;


    private Vector2 LeftStickInput;
    private Vector2 RightStickInput;


    public float baseSpeed = 900;
    public float turnSpeed = 900;
    private float speedMultiplier = .5f;
    public float velocity;
    public float MaxVol = 2.5f;
    public float stoppingForceMultiplier = 250f;
    public float turnStoppingForceMultiplier = 9.8f;
    public float currentDriveSpeed;
    public float currentTurnSpeed;
    public bool grounded;

    string rightBackDirection;
    string rightFrontDirection;
    string leftFrontDirection;
    string leftBackDirection;



    private void Start()
    {
        
    }

    private void Update()
    {
        gamepads = Gamepad.all.ToArray();
        Gamepad WheelInput = /*controllerManager.Driver1Controller*/ gamepads[0];


        float y = WheelInput.leftStick.y.value;
        float x = WheelInput.leftStick.x.value;
        float rx = WheelInput.rightStick.x.value;


        double denominator = Mathf.Max(Mathf.Abs(y) + Mathf.Abs(x) + Mathf.Abs(rx), 1);
        double frontLeftPower = (y + x + rx) / denominator;
        double backLeftPower = (y - x + rx) / denominator;
        double frontRightPower = (y - x - rx) / denominator;
        double backRightPower = (y + x - rx) / denominator;



 

        if (frontLeftPower > 0)
        {
            leftFrontDirection = "Forward";
        }
        else if (frontLeftPower < 0)
        {
            leftFrontDirection = "Backward";
        }


        if (frontRightPower > 0)
        {
            rightFrontDirection = "Forward";
        }
        else if (frontRightPower < 0)
        {
            rightFrontDirection = "Backward";
        }

        if (backLeftPower > 0)
        {
            leftBackDirection = "Forward";
        }
        else if (backLeftPower < 0)
        {
            leftBackDirection = "Backward";
        }


        if (backRightPower > 0)
        {
            rightBackDirection = "Forward";
        }
        else if (backRightPower < 0)
        {
            rightBackDirection = "Backward";
        }

        //Strafe Right
        if (rightBackDirection == "Forward" && rightFrontDirection == "Backward")
        {
            rightBackDirection = "Right";
            rightFrontDirection = "Right";
        }

        if (leftFrontDirection == "Forward" && leftBackDirection == "Backward")
        {
            leftFrontDirection = "Right";
            leftBackDirection = "Right";
        }

        //Strafe left
        if (rightBackDirection == "Backward" && rightFrontDirection == "Foward")
        {
            rightBackDirection = "Left";
            rightFrontDirection = "Left";
        }



        if (leftFrontDirection == "Backward" && leftBackDirection == "Foward")
        {
            leftFrontDirection = "Left";
            leftBackDirection = "Left";
        }

        //Drive forward and backward with each wheel
        if (leftFrontDirection == "Forward" || leftFrontDirection == "Backward")
        {
            CoreRB.AddForceAtPosition(frontLeftWheel.transform.forward * Time.deltaTime * frontLeftPower * Speed);
        }

        if (rightFrontDirection == "Forward" || rightFrontDirection == "Backward")
        {
            //Add forces to left front wheel for foward
        }

        if (leftBackDirection == "Forward" || leftBackDirection == "Backward")
        {
            //Add forces to left front wheel for foward
        }

        if (rightBackDirection == "Forward" || rightBackDirection == "Backward")
        {
            //Add forces to left front wheel for foward
        }


    }

}
}
