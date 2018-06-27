using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballShooter : MonoBehaviour {

    public GameObject baseballPrefab;

    private GameObject baseball;            // For caching
    private Rigidbody baseballRigidbody;    // For caching
    private const float baseballSpeed = 6.0f;
    private const float baseballArc = 2.0f;

    private void Awake() {
        baseball = Instantiate(baseballPrefab);
        baseballRigidbody = baseball.GetComponent<Rigidbody>();
        baseball.SetActive(false);
    }

    private void Start() {
        StartCoroutine(ShootBaseball(3, 5.0f));
    }

    private IEnumerator ShootBaseball(int baseballsShot, float delayTime) {
        if(baseballsShot <= 0) {
            Debug.Log("Baseball shooter is done shooting.");
            yield return null;
        } else {
            yield return new WaitForSeconds(delayTime);
            if (!baseball.activeSelf)
                baseball.SetActive(true);
            baseball.transform.position = transform.position;
            baseballRigidbody.velocity = transform.forward * baseballSpeed + Vector3.up * baseballArc;
            Debug.Log("shot baseball");
            yield return StartCoroutine(ShootBaseball(baseballsShot - 1, delayTime));
        }
    }


}
