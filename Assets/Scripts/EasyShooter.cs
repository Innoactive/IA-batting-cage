using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyShooter : MonoBehaviour,IShooter {

    public void Shoot(GameObject ball,Transform ballSpawnPosition)
    {
        ball.transform.position = ballSpawnPosition.position;
        ball.transform.rotation = ballSpawnPosition.rotation;
        ball.GetComponent<BallEventsObservable>().ReportBallShoot();
        ball.GetComponent<Rigidbody>().AddForce(600f, 20f, 0f);
        ball.GetComponent<TrailRenderer>().Clear();
    }
}
