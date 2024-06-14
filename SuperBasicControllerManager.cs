using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class SuperBasicControllerManager : MonoBehaviour
{
    private Gamepad[] gamepads;

    public Gamepad Driver1Controller;
    public Gamepad Driver2Controller;


    private void Start()
    {
        gamepads = Gamepad.all.ToArray();
        Driver1Controller = gamepads[0];
        Driver2Controller = gamepads[1];
    }


    // Update is called once per frame
    void Update()
    {
        gamepads = Gamepad.all.ToArray();

        if (gamepads == null)
        {
            Debug.Log("Missing one or more gamepads");
            return;
        }


        if (gamepads[0].startButton.isPressed && gamepads[0].buttonSouth.isPressed)
        {
            Driver1Controller = gamepads[0];
        }
        else if (gamepads[0].startButton.isPressed && gamepads[0].buttonEast.isPressed)
        {
            Driver2Controller = gamepads[0];
        }

        if (gamepads[1].startButton.isPressed && gamepads[1].buttonSouth.isPressed)
        {
            Driver1Controller = gamepads[1];
        }
        else if (gamepads[1].startButton.isPressed && gamepads[1].buttonEast.isPressed)
        {
            Driver2Controller = gamepads[1];
        }


    }
}
