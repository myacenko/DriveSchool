using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Canvas result;
    public Text resultText;
    int countOfRate = 0;
    public string currentScene;
    void Start()
    {
        result.enabled = false;
    }
 void OnEnable()
    {
        switch (currentScene)
        {
            case "PreFlyCheck":
                if (PlayerPrefs.GetInt("PreFlyCheck_HandHeld", 0) == 1) { 
                    resultText.text = "Ручной тормоз снят(+1 балл)";
                    countOfRate++;
                    }
                else { 
                    resultText.text = "Начали движение на ручном тормозе(-1)";
                    countOfRate--;
                }
                break;
            case "TraficLightWhithSegment":
                resultText.text = "RafikPoslalVsehNavig";
                break;
        }
    }

}