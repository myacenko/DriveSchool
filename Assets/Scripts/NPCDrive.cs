using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDrive : MonoBehaviour
{


    public Transform[] wheels;

    public float[] secondDrive;
    public float[] motorPower;
    public float[] motorBreak;
    public float[] countOfSteer;
    public float enginePower = 150.0f;
    public float power = 0.0f;
    public float brake = 0.0f;
    public float steer = 0.0f;
    public float maxSteer = 25.0f;
    private Rigidbody rb;
   
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.0f, -0.5f, 0.3f);
        StartCoroutine(Trip());
    }
    IEnumerator Trip()
    {
        for(int i = 0; i < secondDrive.Length;i++)
        {
            steer = countOfSteer[i] * maxSteer;
            brake = motorBreak[i] ==1? 250.0f * rb.mass * 0.2f : 0.0f; ;
            power = motorPower[i]*enginePower* Time.deltaTime * 250;
            yield return new WaitForSeconds(secondDrive[i]);
        }
    }
        void FixedUpdate()
    {
        GetCollider(0).steerAngle = steer;
        GetCollider(1).steerAngle = steer;
   

        if (brake > 0.0)
        {
            GetCollider(0).brakeTorque = brake;
            GetCollider(1).brakeTorque = brake;
            GetCollider(2).brakeTorque = brake;
            GetCollider(3).brakeTorque = brake;
            GetCollider(2).motorTorque = 0.0f;
            GetCollider(3).motorTorque = 0.0f;
        }
        else
        {
            GetCollider(0).brakeTorque = 0.0f;
            GetCollider(1).brakeTorque = 0.0f;
            GetCollider(2).brakeTorque = 0.0f;
            GetCollider(3).brakeTorque = 0.0f;
            GetCollider(2).motorTorque = power;
            GetCollider(3).motorTorque = power;
        
            
        }
    }

    private WheelCollider GetCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }

}
