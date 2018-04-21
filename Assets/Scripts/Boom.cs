using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boom : MonoBehaviour {
    public AudioSource boomPlayerAS;
    public AudioClip boomSound;
    public Light TrafficLight;
    public string currentScene;
    void Start()
    {
        boomPlayerAS.playOnAwake = false;
        boomPlayerAS.clip = boomSound;

    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Floor"))
            return;
        if (hit.gameObject.CompareTag("Check0"))
        {
            PlayerPrefs.SetInt(currentScene + "_Check0", 1);
            GetComponent<EndLesson>().ShowResult();
            return;
        }
        if (hit.gameObject.CompareTag("Check1"))
        {
            PlayerPrefs.SetInt(currentScene + "_Check1", 1);
            GetComponent<EndLesson>().ShowResult();
            return;
        }
        if (hit.gameObject.CompareTag("StopLine") )
        {
            if(TrafficLight.intensity > 0.0f) { 
            PlayerPrefs.SetInt(currentScene + "_StopLine", 1);
            GetComponent<EndLesson>().ShowResult();
        }
            return;
        }
        PlayerPrefs.SetInt(currentScene + "_Crash", 1);
        boomPlayerAS.Play();
    }

}



