using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConeScoring : MonoBehaviour
{
    public bool RedCone;
    public bool BlueCone;

    private bool scored;

    public Score score;

    private void Awake()
    {
       score = FindObjectOfType<Score>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //corners
        if (other.CompareTag("Blue Score") && scored == false && BlueCone == true)
        {
            score.BlueAllianceBotOneScore = score.BlueAllianceBotOneScore + 1;
            scored = true;
        }
        else if (other.CompareTag("Red Score") && scored == false && RedCone == true)
        {
            score.RedAllianceBotOneScore = score.RedAllianceBotOneScore + 1;
            scored = true;
        }
        else
        //Low junction
        if (other.CompareTag("Low junction scoring") && scored == false && BlueCone == true)
        {
            score.BlueAllianceBotOneScore = score.BlueAllianceBotOneScore + 3;
            scored = true;
        }
        else if(other.CompareTag("Low junction scoring") && scored == false && RedCone == true)
        {
            score.RedAllianceBotOneScore = score.RedAllianceBotOneScore + 3;
            scored = true;
        }
        else
        //medium junctions
        if (other.CompareTag("Medium junction scoring") && scored == false && BlueCone == true)
        {
            score.BlueAllianceBotOneScore = score.BlueAllianceBotOneScore + 4;
            scored = true;
        }
        else if (other.CompareTag("Medium junction scoring") && scored == false && RedCone == true)
        {
            score.RedAllianceBotOneScore = score.RedAllianceBotOneScore + 4;
            scored = true;
        }
        else
        //High junctions 
        if (other.CompareTag("High junction scoring") && scored == false && BlueCone == true)
        {
            score.BlueAllianceBotOneScore = score.BlueAllianceBotOneScore + 5;
            scored = true;
        }
        else if (other.CompareTag("High junction scoring") && scored == false && RedCone == true)
        {
            score.RedAllianceBotOneScore = score.RedAllianceBotOneScore + 5;
            scored = true;
        }


    }
}
