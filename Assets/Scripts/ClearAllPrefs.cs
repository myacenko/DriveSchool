using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllPrefs : MonoBehaviour {

    public void ClearAll() {
        PlayerPrefs.DeleteAll();
    }
}
