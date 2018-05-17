using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDrive : MonoBehaviour {


public Transform[] wheels;
public float enginePower=150.0f;
public float power=0.0f;
public float brake=0.0f;
public float steer=0.0f;
public float  maxSteer=25.0f;
private  Rigidbody rb;
public float[] Powers;
public float[] Brakes;
public Transform[] Waypoints;


    void Start(){
    rb = GetComponent <Rigidbody> ();
    rb.centerOfMass=new Vector3(0.0f,-0.5f,0.3f);
    StartCoroutine(go());
    }

    IEnumerator go () {
	Vector3 prevWaypointDir;
    	for(int i=0;i<Waypoints.Length;i++){
    	power= Powers[i] * enginePower * Time.deltaTime *250;
    	brake= Brakes[i]==1 ? 250.0f * rb.mass * 0.2f : 0.0f;
        if (brake > 0.0){
        	GetCollider(0).brakeTorque=brake;
        	GetCollider(1).brakeTorque=brake;
        	GetCollider(2).brakeTorque=brake;
        	GetCollider(3).brakeTorque=brake;
        	GetCollider(2).motorTorque=0.0f;
        	GetCollider(3).motorTorque=0.0f;
    	} else {
        	GetCollider(0).brakeTorque=0.0f;
        	GetCollider(1).brakeTorque=0.0f;
        	GetCollider(2).brakeTorque=0.0f;
        	GetCollider(3).brakeTorque=0.0f;
        	GetCollider(2).motorTorque=power;
        	GetCollider(3).motorTorque=power;
    	}
	prevWaypointDir=Waypoints[i].transform.position - transform.position;
	while(true){
 		Vector3 waypointDir = Waypoints[i].transform.position - transform.position;
                if(waypointDir.magnitude<0.5f ||  prevWaypointDir.magnitude<waypointDir.magnitude) break;   
                 prevWaypointDir=Waypoints[i].transform.position - transform.position;
		float angleBetween = Vector3.SignedAngle (transform.forward, waypointDir, Vector3.up);
		if(angleBetween>0)
                   angleBetween=angleBetween>maxSteer?maxSteer:angleBetween;
		else
		   angleBetween=angleBetween<-maxSteer?-maxSteer:angleBetween;
 		GetCollider(0).steerAngle=angleBetween;
    		GetCollider(1).steerAngle=angleBetween;
	        yield return new WaitForSeconds(0.05f);
		}
   	}
    GetCollider(0).brakeTorque=250.0f * rb.mass * 0.2f;
    GetCollider(1).brakeTorque=250.0f * rb.mass * 0.2f;
    GetCollider(2).brakeTorque=250.0f * rb.mass * 0.2f;
    GetCollider(3).brakeTorque=250.0f * rb.mass * 0.2f;
    }

 
private WheelCollider GetCollider(int n)  {
    return wheels[n].gameObject.GetComponent<WheelCollider>();
}

}
