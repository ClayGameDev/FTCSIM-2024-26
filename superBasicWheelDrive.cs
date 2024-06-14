using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class superBasicWheelDrive : MonoBehaviour
{
    SuperBasicControllerManager controllerManager;
    Gamepad WheelInput;
    Gamepad OtherDriverInput;
    private Gamepad[] gamepads;
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


    // Update is called once per frame
    void FixedUpdate()
    {
        gamepads = Gamepad.all.ToArray();
        WheelInput = /*controllerManager.Driver1Controller*/ gamepads[0];
            if (WheelInput.dpad.up.isPressed || WheelInput.rightTrigger.value > 0.5)
            {
                speedMultiplier = 1;
                Debug.Log("Speed was set to 100%");
            }

            if (WheelInput.dpad.down.isPressed)
            {
                speedMultiplier = 0.25f;
                Debug.Log("Speed was set to 25%");
            }

            if (WheelInput.dpad.left.isPressed || WheelInput.leftTrigger.value > 0.5)
            {
                speedMultiplier = 0.5f;
                Debug.Log("Speed was set to 50%");
            }

            if (WheelInput.dpad.right.isPressed)
            {
                speedMultiplier = 0.75f;
                Debug.Log("Speed was set to 75%");
            }
            currentDriveSpeed = speedMultiplier * baseSpeed;
            currentTurnSpeed = speedMultiplier * turnSpeed;




            LeftStickInput = new Vector2(WheelInput.leftStick.value.x, WheelInput.leftStick.value.y);
            RightStickInput = new Vector2(WheelInput.rightStick.value.x, WheelInput.rightStick.value.y);

            MaxVol = MaxVol * speedMultiplier * LeftStickInput.magnitude;

            velocity = CoreRB.velocity.magnitude;
            if (velocity > MaxVol)
            {
                CoreRB.velocity = CoreRB.velocity.normalized * MaxVol;
            }


            if (RightStickInput.magnitude < 0.1f)
            {
                // Calculate the torque to counteract the rotation
                Vector3 counterTorque = -CoreRB.angularVelocity * turnStoppingForceMultiplier;

                // Apply torque to stop the rotation
                CoreRB.AddTorque(counterTorque);
            }

            if (LeftStickInput.magnitude < 0.1f) // Adjust the threshold as needed
            {
                // Apply a reverse force to slow down the robot
                CoreRB.AddForce((-CoreRB.velocity) * stoppingForceMultiplier);
            }


            // Calculate force to be applied
            Vector3 forceFB = CoreRB.transform.right * -currentDriveSpeed * LeftStickInput.y;
            Vector3 forceLR = CoreRB.transform.forward * currentDriveSpeed * LeftStickInput.x;
            Vector3 forceTF = CoreRB.transform.forward * currentTurnSpeed * RightStickInput.x;
            Vector3 forceTB = CoreRB.transform.forward * -currentTurnSpeed * RightStickInput.x;

            // Apply force at each wheel's position
            //FB
            ApplyFBForceAtWheel(frontRightWheel, forceFB);
            ApplyFBForceAtWheel(backRightWheel, forceFB);
            ApplyFBForceAtWheel(frontLeftWheel, forceFB);
            ApplyFBForceAtWheel(backLeftWheel, forceFB);
        //LR
            ApplyLRForceAtWheel(frontRightWheel, forceLR);
            ApplyLRForceAtWheel(backRightWheel, forceLR);
            ApplyLRForceAtWheel(frontLeftWheel, forceLR);
            ApplyLRForceAtWheel(backLeftWheel, forceLR);
            //Turn
            ApplyTForceAtWheel(frontRightWheel, forceTF);
            ApplyTForceAtWheel(frontLeftWheel, forceTF);
            ApplyTForceAtWheel(backRightWheel, forceTB);
            ApplyTForceAtWheel(backLeftWheel, forceTB);
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    // Apply force at the given wheel's position
    void ApplyFBForceAtWheel(GameObject wheel, Vector3 force)
    {
        //lol
        if (grounded == true)
        {
            CoreRB.AddForceAtPosition(force, wheel.transform.position, ForceMode.Force);
            
        }
    }

    void ApplyLRForceAtWheel(GameObject wheel, Vector3 force)
    {
        //lol
        if (grounded == true)
        {
            CoreRB.AddForceAtPosition(force, wheel.transform.position, ForceMode.Force);

        }
    }

    void ApplyTForceAtWheel(GameObject wheel, Vector3 force)
    {
        if(grounded == true)
        {
            CoreRB.AddForceAtPosition(force, wheel.transform.position, ForceMode.Force);
        }
        
    }
}

