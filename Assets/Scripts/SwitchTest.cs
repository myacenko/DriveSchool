using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchTest : MonoBehaviour {

    public Sprite[] images;
    public string[] texts;
    public Image picture;
    public Text subj;
    public Button[] answers;
    public string[] textAnswers;
    public int[] trueAnswers;
    private int i;
    private int countOfRate;
    private bool clickToResult;
    void Start()
    {
        StartCoroutine(switcher());
    }

    public IEnumerator switcher()
    {
        int j = 0;
        for (i = 0; i < images.Length; i++)
        {
            picture.sprite = images[i];
            subj.text = texts[i];
            countOfRate = 0;
            clickToResult = false;
            answers[0].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[1].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[2].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[0].GetComponentInChildren<Text>().text = textAnswers[j++];
            answers[1].GetComponentInChildren<Text>().text = textAnswers[j++];
            answers[2].GetComponentInChildren<Text>().text = textAnswers[j++];
            for(int k=0;k<30 && !clickToResult;k++)
                yield return new WaitForSeconds(0.5f);
        }
        picture.enabled = false;
        subj.text = "Конец теста";
    }

    public void click1()
    {
        answers[0].transform.Find("Check").GetComponent<Image>().enabled = true;
        if (trueAnswers[i] == 1)
        {
            PlayerPrefs.SetInt("Answer." + i, 1);
            countOfRate++;
            PlayerPrefs.SetInt("AllTestScore", countOfRate + PlayerPrefs.GetInt("AllTestScore", 0));
        }
        else PlayerPrefs.SetInt("Answer." + i, 0);
        clickToResult = true;
    }
    public void click2()
    {
        answers[1].transform.Find("Check").GetComponent<Image>().enabled = true;
        if (trueAnswers[i] == 2)
        {
            PlayerPrefs.SetInt("Answer." + i, 1);
            countOfRate++;
            PlayerPrefs.SetInt("AllTestScore", countOfRate + PlayerPrefs.GetInt("AllTestScore", 0));
        }
        else PlayerPrefs.SetInt("Answer." + i, 0);
        clickToResult = true;
    }
    public void click3()
    {
        answers[2].transform.Find("Check").GetComponent<Image>().enabled = true;
        if (trueAnswers[i] == 3)
        {
            PlayerPrefs.SetInt("Answer." + i, 1);
            countOfRate++;
            PlayerPrefs.SetInt("AllTestScore", countOfRate + PlayerPrefs.GetInt("AllTestScore", 0));
        }
        else PlayerPrefs.SetInt("Answer." + i, 0);
        clickToResult = true;
    }

}

