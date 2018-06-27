using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearMissDetector : MonoBehaviour
{
    public Action<Collision> OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (OnCollision != null)
            OnCollision(collision);
    }
}
