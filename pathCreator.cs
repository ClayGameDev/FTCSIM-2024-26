using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathCreator : MonoBehaviour
{
    bool canMove = true;
    bool readyToPlace = false;
    bool canTurn = false;
    public PlayerInput playerInput1;

    public float speed;

    public GameObject robot;
    public GameObject DriveAutoPoint;
    public GameObject TurnAutoPoint;
    public GameObject ActionAutoPoint;
    public GameObject settingsChangeAutoPoint;

    private Gamepad gamepad; // Changed to lowercase for consistency

    private Vector2 movementInput;
    private Vector2 turnInput;
    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the gamepad
        gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.LogWarning("No gamepad found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad != null)
        {
            // Get movement input from the left stick
            movementInput = gamepad.leftStick.ReadValue();


            // Calculate the new position based on input
            float xValue = -movementInput.x * speed * Time.deltaTime;
            float yValue = -movementInput.y * speed * Time.deltaTime;
            movementVector = new Vector3(robot.transform.position.x + xValue, robot.transform.position.y, robot.transform.position.z + yValue);

            // Update the robot's position
            if (canMove == true)
            {
                robot.transform.position = movementVector;

                if (robot.transform.position.z > 1.634)
                {
                    //robot.transform.position.z= 1.634;
                }

                if (gamepad.buttonSouth.wasPressedThisFrame)
                {
                    canMove = false;
                    bool readyToPlace = true;
                }
            }

            if (readyToPlace = true)
            {
                //make move position
                if (gamepad.buttonSouth.isPressed)
                {
                    Instantiate(DriveAutoPoint, robot.transform.position, robot.transform.rotation);
                    readyToPlace = false;
                    canMove = true;
                }

                // make turn position
                if (gamepad.buttonNorth.isPressed)
                {
                    Instantiate(TurnAutoPoint, robot.transform.position, robot.transform.rotation);
                    readyToPlace = false;
                    canMove = true;
                }
            }

        }
    }
}