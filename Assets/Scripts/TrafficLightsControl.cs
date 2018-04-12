using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsControl : MonoBehaviour {
    public Light[] lights;
    public Light segment;


	void Start () {
        offAll();
        StartCoroutine(switchLight());
    }

    private void offAll() {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0.0f;
            segment.intensity = 0.0f;
        }
    }

    IEnumerator switchLight()
    {
        while (true)
        {
            offAll();
            //green
            lights[2].intensity = 5.0f;
            lights[14].intensity = 5.0f;
            lights[5].intensity = 5.0f;
            lights[17].intensity = 5.0f;
            //red
            lights[6].intensity = 5.0f;
            lights[9].intensity = 5.0f;
            lights[18].intensity = 5.0f;
            lights[21].intensity = 5.0f;
            yield return new WaitForSeconds(10.0f);
            offAll();
            //yellow
            lights[1].intensity = 5.0f;
            lights[4].intensity = 5.0f;
            lights[7].intensity = 5.0f;
            lights[10].intensity = 5.0f;
            lights[13].intensity = 5.0f;
            lights[16].intensity = 5.0f;
            lights[19].intensity = 5.0f;
            lights[22].intensity = 5.0f;
            yield return new WaitForSeconds(2.0f);
            offAll();
            segment.intensity = 5.0f;
            //red
            lights[0].intensity = 5.0f;
            lights[3].intensity = 5.0f;
            lights[9].intensity = 5.0f;
            lights[12].intensity = 5.0f;
            //green
            lights[8].intensity = 5.0f;
            lights[11].intensity = 5.0f;
            lights[20].intensity = 5.0f;
            lights[23].intensity = 5.0f;
            yield return new WaitForSeconds(10.0f);
            //yellow
            lights[1].intensity = 5.0f;
            lights[4].intensity = 5.0f;
            lights[7].intensity = 5.0f;
            lights[10].intensity = 5.0f;
            lights[13].intensity = 5.0f;
            lights[16].intensity = 5.0f;
            lights[19].intensity = 5.0f;
            lights[22].intensity = 5.0f;
            yield return new WaitForSeconds(2.0f);
        }
    }
}


