using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmDriver : MonoBehaviour
{
    public gameManager gamemanager;
    public Gamepad[] gamepads;


    private Gamepad secondDriverInput;

    public Animator anim;
    public GameObject robotModel;
    private float slideInput;


    public bool clawClosed = false;
    private bool armUp = false;


    void Start()
    {
       anim = robotModel.GetComponent<Animator>();
        

    }
        // Update is called once per frame
        void Update()
        {
         gamepads = Gamepad.all.ToArray();
         secondDriverInput = /*controllerManager.Driver2Controller*/ gamepads[1];
            slideInput = secondDriverInput.leftStick.value.y;

        anim.updateMode = AnimatorUpdateMode.AnimatePhysics;
         anim.SetFloat("slideSpeed", slideInput);

        


            if (secondDriverInput.buttonSouth.isPressed && clawClosed == false || secondDriverInput.rightTrigger.isPressed && clawClosed == false)
            {

                anim.SetTrigger("CloseClaw");
                clawClosed = true;

            }
            else if (secondDriverInput.buttonEast.isPressed && clawClosed == true || secondDriverInput.leftTrigger.isPressed && clawClosed == true)
            {
                anim.SetTrigger("OpenClaw");
                clawClosed = false;
            }

            if (secondDriverInput.buttonNorth.isPressed && armUp == false)
            {
                anim.SetTrigger("RotateServoArmUp");
                armUp = true;
            }
            else if (secondDriverInput.buttonWest.isPressed && armUp == true)
            {
                anim.SetTrigger("RotateServoArmDown");
                armUp=false;
            }
        }
}
