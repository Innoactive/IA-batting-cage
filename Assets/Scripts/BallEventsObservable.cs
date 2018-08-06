using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEventsObservable : MonoBehaviour {

    public delegate void Ballhit(GameObject with,GameObject ball);
    public delegate void BallShot();
    public delegate void NearMiss();

    public static event NearMiss OnNearMiss;
    public static event BallShot OnBallShot;
    public static event Ballhit OnBallHit;

    bool hasTouchedBat = false;
    public void ReportBallShoot() {
        hasTouchedBat = false;
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

        if(!hasTouchedBat && collision.gameObject.tag.Equals("Bat"))
        {
            hasTouchedBat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO  implement Nearmiss
        if (!hasTouchedBat && other.tag.Equals("Bat")) {
            if (OnNearMiss != null) {
                OnNearMiss();
            }
        }
    }
}
