using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Canvas result;
    public Text resultText;
    private int countOfRate = 0;
    public string currentScene;
    void Start()
    {
        result.enabled = false;
    }
    public void SetText()
    {
        countOfRate = 0;
        resultText.text = "";
        switch (currentScene)
        {
            case "PreFlyCheck":
                // ручник
                if (PlayerPrefs.GetInt("PreFlyCheck_HandHeld", 0) == 1) { 
                    resultText.text += "Ручной тормоз снят(+1 балл)\n";
                    countOfRate++;
                    }
                else { 
                    resultText.text += "Начали движение на ручном тормозе(-1 балл)\n";
                    countOfRate--;
                }
                // ремень
                if (PlayerPrefs.GetInt("PreFlyCheck_Belt", 0) == 1)
                {
                    resultText.text += "Пристегнулись(+1 балл)\n";
                    countOfRate++;
                }
                else
                {
                    resultText.text += "Ремень безопасности не пристегнут(-1 балл)\n";
                    countOfRate--;
                }
                // зеркала
                if (PlayerPrefs.GetInt("PreFlyCheck_Miror1", 0) == 1 || PlayerPrefs.GetInt("PreFlyCheck_Miror2", 0) == 1)
                {
                    resultText.text += "Зеркала настроены(+1 балл)\n";
                    countOfRate++;
                }
                else
                {
                    resultText.text += "Водитель не настроил зеркала(-1 балл)\n";
                    countOfRate--;
                }

                break;
            case "TraficLightWhithSegment":
                if (PlayerPrefs.GetInt("TraficLightWithSegment_Check0", 0) == 1)
                {
                    resultText.text += "Поворот в правильном направлении(+1 балл)\n";
                    countOfRate++;
                }
                else if (PlayerPrefs.GetInt("TraficLightWithSegment_Check1", 0) == 1)
                {
                    resultText.text += "Поворот в неправильном направлении(-1 балл)\n";
                    countOfRate--;

                }
                if (PlayerPrefs.GetInt("TraficLightWithSegment_Crash",0) == 1)
                {
                    resultText.text += "Вы допустили столкновение (-5 балл)\n";
                    countOfRate-=5;
                }
                if (PlayerPrefs.GetInt("TraficLightWithSegment_StopLine", 0) == 1)
                {
                    resultText.text += "Вы проехали на разрешающий сигнал светофора(+1 балл)\n";
                    countOfRate += 1;
                }
                else
                {
                    resultText.text += "Вы проехали на запрещающий сигнал светофора(-1 балл)\n";
                    countOfRate -= 1;
                }
                break;
            case "MainRoad":
                if (PlayerPrefs.GetInt("MainRoad_Check0", 0) == 1)
                {
                    countOfRate++;
                    resultText.text += "Поворот в правильном направлении(+1 балл)\n";
                }
                else if (PlayerPrefs.GetInt("MainRoad_Check1", 0) == 1)
                {
                    resultText.text += "Поворот в неправильном направлении(-1 балл)\n";
                    countOfRate--;
                }
                if (PlayerPrefs.GetInt("MainRoad_Crash", 0) == 1)
                {
                    resultText.text += "Вы допустили столкновение (-5 балл)\n";
                    countOfRate -= 5;
                }
                    break;
        }
        PlayerPrefs.SetInt("AllDriveScore", countOfRate+PlayerPrefs.GetInt("AllDriveScore", 0));
    }

}