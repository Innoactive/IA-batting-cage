using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballShooter : MonoBehaviour {

    public GameObject baseballPrefab;

    private GameObject baseball;            // For caching
    private Rigidbody baseballRigidbody;    // For caching
    private const int baseballTotalShots = 20;
    private const float baseballSpeed = 6.0f;
    private const float baseballArc = 2.0f;
    private const float regularDelayTime = 5.0f;
    private int baseballTotalHits;
    private bool lastBaseballWasHit;

    public void BatHit() {
        baseballTotalHits++;
        lastBaseballWasHit = true;
        Debug.Log("Total hits: " + baseballTotalHits);
    }


    private void Awake() {
        baseball = Instantiate(baseballPrefab);
        baseballRigidbody = baseball.GetComponent<Rigidbody>();
        baseball.SetActive(false);
        baseballTotalHits = 0;
        lastBaseballWasHit = true;  // For first throw, so it doesn't decrement
    }

    private void Start() {
        StartCoroutine(ShootBaseball(baseballTotalShots, 5.0f));
    }

    private IEnumerator ShootBaseball(int baseballsShot, float delayTime) {
        if(baseballsShot <= 0) {
            Debug.Log("Baseball shooter is done shooting.");
            yield return null;
        } else {
            if (!lastBaseballWasHit && delayTime == regularDelayTime)
                delayTime -= 1;
            else if(lastBaseballWasHit)
                delayTime = regularDelayTime;
            lastBaseballWasHit = false;
            yield return new WaitForSeconds(delayTime);
            if (!baseball.activeSelf)
                baseball.SetActive(true);
            baseball.transform.position = transform.position;
            baseballRigidbody.velocity = transform.forward * baseballSpeed + Vector3.up * baseballArc;
            yield return StartCoroutine(ShootBaseball(baseballsShot - 1, delayTime));
        }
    }


}
