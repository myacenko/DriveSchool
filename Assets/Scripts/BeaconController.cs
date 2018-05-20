using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconController : MonoBehaviour {

    public Light beacon, beacon1, beacon2, beacon3;

	void Start () {
        StartCoroutine(switchLight());
    }

    IEnumerator switchLight()
    {
        while (true)
        {
            beacon.intensity = 3.0f;
            beacon1.intensity = 3.0f;
            beacon2.intensity = 3.0f;
            beacon3.intensity = 3.0f;
            yield return new WaitForSeconds(1.0f);
            beacon.intensity = 0.0f;
            beacon1.intensity = 0.0f;
            beacon2.intensity = 0.0f;
            beacon3.intensity = 0.0f;
            yield return new WaitForSeconds(1.0f);
        }
        
    }
    }
