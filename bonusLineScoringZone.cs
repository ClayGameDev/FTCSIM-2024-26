using System;
using UnityEngine;

public class bonusLineScoringZone : MonoBehaviour
{
    public Score score;
    public bool scored = false;
    public bool Red = false;
    public bool Blue = false;
    public bool ready = false;
    public Pixel pixelScript;
    public Rigidbody rb;

    // Start is called before the first frame update
    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pixel") && scored == false)
        {
            //pixelScript = collision.gameObject.GetComponent<Pixel>();
            //rb = collision.gameObject.GetComponent<Rigidbody>();
            if (pixelScript != null && rb != null) // Added null checks for pixelScript and rb
            {
                if (rb.velocity.magnitude == 0)
                {
                    ready = true;
                }
            }
        }
    }

    void Update()
    {
        if (ready)
        {
            if (Blue && !scored)
            {
                score.BlueAllianceBotOneScore += 10;
                scored = true;
            }
            else if (Red && !scored)
            {
                score.RedAllianceBotOneScore += 10;
                scored = true;
            }
        }
    }
}
