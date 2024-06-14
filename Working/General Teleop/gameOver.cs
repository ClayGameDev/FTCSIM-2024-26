using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class gameOver : MonoBehaviour
{


    public Score score;
    public timer timer;
    public gameManager gameManager;
    public GameObject gameOverText;
    public GameObject endgameText;
    public GameObject redTextHolder;
    public GameObject blueTextHolder;
    private TextMeshProUGUI redScoreText;
    private TextMeshProUGUI  blueScoreText;
    public TextMeshProUGUI FinalScoreText;

    private string BlueTeamString;


    private float BlueScore;
    private float RedScore;


    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        endgameText.SetActive(false);
        redScoreText= redTextHolder.GetComponent<TextMeshProUGUI>();
        blueScoreText = blueTextHolder.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        BlueScore = score.BlueAllianceScore;
        RedScore = score.RedAllianceScore;

        

        blueScoreText.text = BlueScore.ToString();
        redScoreText.text = RedScore.ToString();

        BlueTeamString = BlueScore.ToString();

        FinalScoreText.text = "Final Score:" + BlueScore.ToString();


        if (gameManager.simulationStopped == true)
        {
           gameOverText.SetActive (true);
        }

        if (gameManager.endgame == true)
        {
            
            endgameText.SetActive (true);
        }
           
    }
}
