	﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//source from https://www.youtube.com/watch?v=LLKYbwNnKDg

public class Reticle : MonoBehaviour {

	public Camera CameraFacing;
	private Vector3 originalScale;

	public void Start(){
		originalScale=transform.localScale;
	}

	public void Update(){
		RaycastHit hit;
		float distance=2.0f;
        if (Physics.Raycast(new Ray(CameraFacing.transform.position,
                    CameraFacing.transform.rotation * Vector3.forward),
                   out hit))
        {
//            if (Physics.Raycast(new Ray(CameraFacing.transform.position,
//                        CameraFacing.transform.TransformDirection( Vector3.forward)),
//                        out hit))
//            {
                distance = hit.distance;
		} else {
//            distance = CameraFacing.farClipPlane;
            distance = CameraFacing.farClipPlane;
        }
        transform.position=CameraFacing.transform.position+
			CameraFacing.transform.rotation*Vector3.forward * distance;
		transform.LookAt(CameraFacing.transform.position);
		transform.Rotate(0.0f,180.0f,0.0f);
		if(distance<10.0f) {
			distance *= 1+5*Mathf.Exp(-distance);
		}
		transform.localScale= originalScale * distance;
	}	
}
