using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZoneAid : MonoBehaviour {

    private HitZone hitZone;
    private Rigidbody hitZoneRigidBody;
    private static float hitScalar = 100f;

    public void InitializeHitZone(HitZone hitZone) { this.hitZone = hitZone; }

    private void Awake() {
        hitZoneRigidBody = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    private void FixedUpdate() {
        Vector3 target = hitZone.transform.position;

        hitZoneRigidBody.transform.rotation = transform.rotation;
        Vector3 velocity = (target - hitZoneRigidBody.transform.position) * hitScalar;
        hitZoneRigidBody.velocity = velocity;
        transform.rotation = hitZone.transform.rotation;
    }

}
