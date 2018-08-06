using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    GameObject trackedObject = null;
    public Text speedText;
    public Text ballsMissedText;
    public Text ScoreText;
    int ballsMissed = 0;
    int topSpeedOfShot = 0;
    int totalSpeed = 0;
    private void OnEnable()
    {
        BallEventsObservable.OnBallHit += BallEventsObservable_OnBallHit;
        BallEventsObservable.OnBallShot += BallEventsObservable_OnBallShot;
    }


    private void OnDisable()
    {
        BallEventsObservable.OnBallHit -= BallEventsObservable_OnBallHit;
        BallEventsObservable.OnBallShot -= BallEventsObservable_OnBallShot;

    }

    private void BallEventsObservable_OnBallShot()
    {

    }
 
    private void BallEventsObservable_OnBallHit(GameObject with,GameObject ball)
    {
        
        if (with.tag.Equals("Bat"))
        {
            trackedObject = ball;
        }
        else {
            trackedObject = null;
            totalSpeed += topSpeedOfShot;
            topSpeedOfShot = 0;
        }

        if (with.tag.Equals("BackFence"))
        {
            ballsMissed++;
        }
    }


    private void Update()
    {
        SyncTexts();
    }

    void SyncTexts()
    {
        if(trackedObject != null)
        {
            float velocity = trackedObject.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
            if ((int)velocity > topSpeedOfShot) {
                topSpeedOfShot = (int)velocity;
            }
            speedText.text = "Speed : " + topSpeedOfShot.ToString("F2");
        }
        ballsMissedText.text = "Missed :" + ballsMissed.ToString();
        ScoreText.text = "Score : " + totalSpeed.ToString();
    }


}
