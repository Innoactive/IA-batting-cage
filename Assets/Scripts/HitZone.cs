using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour {

    public GameObject hitZoneAidPrefab;


    private void Start() {
        GameObject hitZoneAid = Instantiate(hitZoneAidPrefab);
        hitZoneAid.transform.position = transform.position;
        hitZoneAid.GetComponent<HitZoneAid>().InitializeHitZone(this);
    }


}
