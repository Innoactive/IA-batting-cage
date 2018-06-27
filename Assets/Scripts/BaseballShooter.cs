using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseballShooter : MonoBehaviour {

    public GameObject baseballPrefab;
    public Text totalBaseballsHitText;

    private GameObject baseball;            // For caching
    private Rigidbody baseballRigidbody;    // For caching
    private const int baseballTotalShots = 20;  // The total amount of baseballs to shoot
    private const float baseballSpeed = 6.0f;   // The speed at which to shoot the baseballs
    private const float baseballArc = 2.0f;     // The arc scalar at which to shoot the baseballs at
    private const float regularDelayTime = 5.0f;    // The time delay if no misses occur
    private int currentBaseballHits;        // The current number of baseball hits
    private bool lastBaseballWasHit;        // Will return true if the last baseball was hit, else false

    public void BatHit() {
        currentBaseballHits++;
        totalBaseballsHitText.text = currentBaseballHits.ToString();
        lastBaseballWasHit = true;
    }


    private void Awake() {
        baseball = Instantiate(baseballPrefab);
        baseballRigidbody = baseball.GetComponent<Rigidbody>();
        baseball.SetActive(false);
        currentBaseballHits = 0;
        totalBaseballsHitText.text = currentBaseballHits.ToString();
        lastBaseballWasHit = true;  // Initialized to true so first throw doesn't decrement delay time
    }

    private void Start() {
        StartCoroutine(ShootBaseball(baseballTotalShots, 5.0f));
    }

    /* Takes in a count of the baseball shots left to shoot and the delay time. If the baseball shots left is
     * greater than 0, will shoot a baseball. Will alter the delay time based on if the last baseball was hit. */
    private IEnumerator ShootBaseball(int baseballShotsLeft, float delayTime) {
        if(baseballShotsLeft <= 0) {
            yield return null;
        } else {
            if (!lastBaseballWasHit && delayTime == regularDelayTime)   // If last baseball wasn't hit, and delay time hasn't already been decremented
                delayTime -= 1;
            else if(lastBaseballWasHit)
                delayTime = regularDelayTime;
            lastBaseballWasHit = false;
            yield return new WaitForSeconds(delayTime);
            if (!baseball.activeSelf)
                baseball.SetActive(true);
            baseball.transform.position = transform.position;
            baseballRigidbody.velocity = transform.forward * baseballSpeed + Vector3.up * baseballArc;
            yield return StartCoroutine(ShootBaseball(baseballShotsLeft - 1, delayTime));
        }
    }


}
