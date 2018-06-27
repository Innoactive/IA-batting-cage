using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    public GameObject baseballShooter;

    private const string baseballTag = "Baseball";
    private BaseballShooter baseballShooterScript;

    private void Awake() {
        baseballShooterScript = baseballShooter.GetComponent<BaseballShooter>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(string.Equals(collision.gameObject.tag, baseballTag)) {
            baseballShooterScript.BatHit();
        }
    }

}
