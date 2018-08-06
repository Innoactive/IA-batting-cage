using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEventsObservable : MonoBehaviour {

    public delegate void Ballhit(GameObject with,GameObject ball);
    public delegate void BallShot();

    public static event BallShot OnBallShot;
    public static event Ballhit OnBallHit;

    public void ReportBallShoot() {

        if (OnBallShot != null)
        {
            OnBallShot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (OnBallHit != null) {
            OnBallHit(collision.gameObject,gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO  implement Nearmiss
    }
}
