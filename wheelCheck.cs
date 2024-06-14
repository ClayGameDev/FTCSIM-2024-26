using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelCheck : MonoBehaviour
{
    public bool frontLeft;
    public bool frontRight;
    public bool backLeft;
    public bool backRight;
    
    
    public bool WheelGrounded = false;


    public void Update()
    {
        

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
                WheelGrounded = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            WheelGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
                WheelGrounded = false;
        }
    }
}
