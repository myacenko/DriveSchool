using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItems : MonoBehaviour {
    public string item;
public void Check()
    {
        PlayerPrefs.SetInt(item, 1);
    }
}
