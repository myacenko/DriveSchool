using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AllScoreBoard : MonoBehaviour {
    public Canvas result;
    public Text resultText;

    void Start () {
        result.enabled = false;
        if (PlayerPrefs.GetInt("AllDriveScore",0)!=0)
        {
            resultText.text = "Вы набрали за вождение: " + PlayerPrefs.GetInt("AllDriveScore", 0) + "\n" + "Максимальный балл: 10";
            result.enabled = true;
        }
        if (PlayerPrefs.GetInt("AllTestScore", 0) != 0)
        {
            resultText.text = "Вы набрали на тестировании: " + PlayerPrefs.GetInt("AllTestScore", 0) + "\n" + "Максимальный балл: 20";
            result.enabled = true;
        }
    }
	
	
}
