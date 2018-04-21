	﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//source from https://www.youtube.com/watch?v=LLKYbwNnKDg

public class Reticle : MonoBehaviour {

	public Camera CameraFacing;
	private Vector3 originalScale;
	public LayerMask mask = -1;

	public void Start(){
		originalScale=transform.localScale;
		originalScale =  new Vector3(0.05f, 0.05f, 0.05f);
	}

	public void Update(){
		RaycastHit hit;
		float distance;
		if(Physics.Raycast (new Ray(CameraFacing.transform.position,
					CameraFacing.transform.rotation*Vector3.forward),
				    out hit,Mathf.Infinity, mask.value)){
			distance=hit.distance;
		} else {
			distance=CameraFacing.farClipPlane * 0.95f;
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
