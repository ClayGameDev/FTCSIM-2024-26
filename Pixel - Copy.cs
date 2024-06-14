using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public Score score;
    public bool scored;
    public bool canBeRedBoardScored = false;
    public bool canBeBlueBoardScored = false;
    public bool touchingLeftClaw = false;
    public bool touchingRightClaw = false;
    public bool touchingGrabPoint = false;
    public bool freezeSignalSent = false;
    bool frozen = false;
    public Rigidbody rb;
    public GameObject freezePoint;
    public GameObject Arm;
    public ArmDriver claw;
    public MeshCollider MeshCollider;
    public float velocity;
    public float offsetX = 3.72f;
    public float offsetY = -0.05f;
    public float offsetZ = -0.32f;

    // Start is called before the first frame update
    private void Awake()
    {
        score = FindObjectOfType<Score>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();    
    }

    void FixedUpdate()
    {
        velocity = rb.velocity.magnitude;

        if (canBeBlueBoardScored && scored == false && rb.velocity.magnitude <= 0.01)
        {
            score.BlueAllianceBotOneScore += 3;
            scored = true;
        }
        else if (canBeRedBoardScored && scored == false && rb.velocity.magnitude <= 0.01)
        {
            score.RedAllianceBotOneScore += 3;
            scored = true;
        }

        /*
        if (touchingLeftClaw == true && touchingRightClaw == true && claw.clawClosed == true && freezeSignalSent != true)
        {
            FreezePixel();
        }*/

        if (touchingGrabPoint == true  && claw.clawClosed == true && freezeSignalSent != true)
        {
            freezePixel();
        }

        /*
        if (claw.clawClosed == false)
        {
            releasePixel();
        }
        */
        /*
        if (frozen == true)
        {

            float XPosDifference =  freezePoint.transform.position.x - transform.position.x;
            float YPosDifference =  freezePoint.transform.position.y - transform.position.y;
            float ZPosDifference =  freezePoint.transform.position.z - transform.position.z;

            float goToX = transform.position.x + XPosDifference;
            float goToY = transform.position.y + YPosDifference;
            float goToZ = transform.position.z + ZPosDifference;
            rb.useGravity = false;
            Vector3 goHere = new Vector3(goToX, goToY, goToZ);
            transform.position = goHere;

        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("LeftClaw"))
        {
            touchingLeftClaw = true;
        }
        
        if (other.CompareTag("RightClaw"))
        {
            touchingRightClaw = true;
        }
       */
        
        if (other.CompareTag("GrabPoint"))
        {
            touchingGrabPoint = true;
        }
        

        if (other.CompareTag("Blue Backstage") && scored == false)
        {
            score.BlueAllianceBotOneScore += 1;
            scored = true;
        }
        else if (other.CompareTag("Red Backstage") && scored == false)
        {
            score.RedAllianceBotOneScore += 1;
            scored = true;
        }
        else if (other.CompareTag("Blue Board") && scored == false)
        {
            canBeBlueBoardScored = true;
        }
        else if (other.CompareTag("Red Board") && scored == false)
        {
            canBeRedBoardScored = true;
        }


    }

    private void OnTriggerStay(Collider other) 
    {
        /*
        if (other.CompareTag("LeftClaw"))
        {
            touchingLeftClaw = true;
        }

        if (other.CompareTag("RightClaw"))
        {
            touchingRightClaw = true;
        }
        */

        if (other.CompareTag("GrabPoint"))
        {
            touchingGrabPoint = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        /*
        if (other.CompareTag("LeftClaw"))
        {
            touchingLeftClaw = false;
        }

        if (other.CompareTag("RightClaw"))
        {
            touchingRightClaw = false;
        }
        
        */
        if (other.CompareTag("GrabPoint"))
        {
            touchingGrabPoint = false;
        }
        







        // Check if the pixel was previously scored before subtracting points.
        if (scored)
        {
            if (other.CompareTag("Blue Board") && canBeBlueBoardScored && scored)
            {
                score.BlueAllianceBotOneScore -= 3; // Subtract the same amount as when scoring.
            }
            else if (other.CompareTag("Red Board") && canBeRedBoardScored && scored)
            {
                score.RedAllianceBotOneScore -= 3; // Subtract the same amount as when scoring.
            }
            else if (other.CompareTag("Blue Backstage") && scored)
            {
                score.BlueAllianceBotOneScore -= 1;
            }
            else if(other.CompareTag("Red Backstage") && scored)
            {
                score.RedAllianceBotOneScore -= 1;
            }
            scored = false;
            canBeBlueBoardScored = false;
            canBeRedBoardScored = false;
        }
    }
    

    void freezePixel()
    {
        freezeSignalSent = true;
        frozen = true;
        //MeshCollider.enabled = false;
        
       FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        
        joint.connectedBody = Arm.GetComponent<Rigidbody>();




        // Disable automatic configuration of connected anchor
        joint.autoConfigureConnectedAnchor = false;
    }

    void releasePixel()
    {
        
        freezeSignalSent = false;
        frozen = false;
        MeshCollider.enabled = true;
        FixedJoint jointToDestroy = GetComponent<FixedJoint>();
        Destroy(jointToDestroy);
        //rb.useGravity = true;
    }
        




    
}
