using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLesson : MonoBehaviour {
    public Canvas result;
public void ShowResult()
    {
        result.enabled = true;
        result.GetComponent<ShowResult>().SetText();
    }
}
