using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    private static readonly Vector3 localPosition = new Vector3(0.009f, 0.204f, 0.207f);
    private static readonly Quaternion localRotation = Quaternion.Euler(-1.342f, 90.154f, -43.885f);

	private void Awake () {
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
	}

}
