using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    public GameObject baseballShooter;

    private const string baseballTag = "Baseball";
    private BaseballShooter baseballShooterScript;
    private Vector3 baseballShooterBack;
    private float batSpeed = 5.0f;

    private void Awake() {
        baseballShooterScript = baseballShooter.GetComponent<BaseballShooter>();
        baseballShooterBack = baseballShooter.transform.forward * -1;
    }

    private void OnCollisionEnter(Collision collision) {
        if(string.Equals(collision.gameObject.tag, baseballTag)) {
            collision.gameObject.GetComponent<Rigidbody>().velocity = baseballShooterBack * batSpeed;
            baseballShooterScript.BatHit();
        }
    }

}
