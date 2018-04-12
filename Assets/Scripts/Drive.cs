using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {


public Transform[] wheels;
    public Transform helm;
public float enginePower=150.0f;
public float power=0.0f;
public float brake=0.0f;
public float steer=0.0f;
public float  maxSteer=25.0f;
private  Rigidbody rb;
    private AudioSource enginePlayerAudio;
    private float currentVolumeEngine = 0.0f;
    private float currentPitchEngine = 1.0f;

    void Start(){
    rb = GetComponent <Rigidbody> ();
    rb.centerOfMass=new Vector3(0.0f,-0.5f,0.3f);
        enginePlayerAudio = gameObject.GetComponent<AudioSource>();
        currentVolumeEngine = enginePlayerAudio.volume;
        currentPitchEngine = enginePlayerAudio.pitch;
    }

    void FixedUpdate () {
    Vector2 touch=OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
    power= touch.y * enginePower * Time.deltaTime *250;
    steer= touch.x * maxSteer;
    brake=OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) ? 250.0f * rb.mass * 0.2f : 0.0f;
   
    GetCollider(0).steerAngle=steer;
    GetCollider(1).steerAngle=steer;
        helm.transform.localEulerAngles= new Vector3(0, 0, -steer);

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
            enginePlayerAudio.volume += Mathf.Abs(touch.y) ;
            if (enginePlayerAudio.pitch < 1.6f) 
                enginePlayerAudio.pitch += Mathf.Abs(touch.y) ;
        
    }
        if (enginePlayerAudio.volume > currentVolumeEngine)
            enginePlayerAudio.volume -= 0.2f;
        if (enginePlayerAudio.pitch > currentPitchEngine)
            enginePlayerAudio.pitch -= 0.2f;
    }
 
private WheelCollider GetCollider(int n)  {
    return wheels[n].gameObject.GetComponent<WheelCollider>();
}

}
