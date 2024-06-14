using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float BlueAllianceScore = 0f;
    public float BlueAllianceBotOneScore = 0f;
    public float BlueAllianceBotTwoScore = 0f;

    public float RedAllianceScore = 0f;
    public float RedAllianceBotOneScore = 0f;
    public float RedAllianceBotTwoScore = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlueAllianceScore = BlueAllianceBotOneScore + BlueAllianceBotTwoScore;
        RedAllianceScore = RedAllianceBotOneScore + RedAllianceBotTwoScore;
    }
}
