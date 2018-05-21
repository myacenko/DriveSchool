using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultToFace : MonoBehaviour {
    public Camera CameraFacing;
	void Update () {
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);
        transform.position = CameraFacing.transform.position +
        CameraFacing.transform.rotation * Vector3.forward * 1.0f;
    }
}
