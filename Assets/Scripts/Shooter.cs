using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {
    public GameObject ball;
    public Transform ballSpawnPosition;
    public float waitTime;
    public int TotalShots;
    public Image FeedbackLight;

    IShooter shooter;

    private void OnEnable()
    {
        BallEventsObservable.OnBallHit += BallEventsObservable_OnBallHit;
    }

    private void OnDisable()
    {
        BallEventsObservable.OnBallHit -= BallEventsObservable_OnBallHit;
    }

    private void BallEventsObservable_OnBallHit(GameObject with,GameObject ball)
    {
        if (with.tag.Equals("BackFence")) {
            waitTime =- 1 ;
        }
        if (with.tag.Equals("Bat"))
        {
            waitTime = 5;
        }
    }

    private void Start()
    {
        StartCoroutine(ShootForMatch());
        shooter = gameObject.AddComponent<EasyShooter>();
    }

    IEnumerator ShootForMatch()
    {
        for (int i = 0; i < TotalShots; i++) {
            FeedbackLight.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(waitTime-1);
            //Turn on Green Light
            FeedbackLight.color = new Color(0, 1, 0);
            yield return new WaitForSeconds(1);
            shooter.Shoot(ball, ballSpawnPosition);
        }

    }

}
