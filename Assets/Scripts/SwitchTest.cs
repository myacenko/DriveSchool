using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class SwitchTest : MonoBehaviour {

    Texture2D[] images;
    string[] texts;
    public RawImage picture;
    public Text subj;
    public Button[] answers;
    string[] textAnswers;
    string[] trueAnswers;
    private int i=0;
    public TextAsset textTest1;
    public TextAsset textAnswers1;
    public TextAsset trueAnswers1;
    private int countOfRate;
    string imagePath = "texturesTest";
    private bool clickToResult;
    void Start()
    {
        Object[] textures = Resources.LoadAll(imagePath);
       images = new Texture2D[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
           images[i] = (Texture2D)textures[i];
        }
        string fs = textTest1.text;
        texts = Regex.Split(fs, "-----");
        fs = textAnswers1.text;
        textAnswers = Regex.Split(fs, "-----");
        fs = trueAnswers1.text;
        //int number = Convert.ToInt32(value, 10);
        trueAnswers = Regex.Split(fs, "-----");
        StartCoroutine(switcher());
    }

    public IEnumerator switcher()
    {
        int j = 0;
   
        for (i = 0; i < texts.Length; i++)
        {
            subj.text = texts[i];
            if (images.Length > i)
            {
                picture.texture = images[i];
            }

            countOfRate = 0;
            clickToResult = false;
            answers[0].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[1].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[2].transform.Find("Check").GetComponent<Image>().enabled = false;
            answers[0].GetComponentInChildren<Text>().text = textAnswers[j++];
            answers[1].GetComponentInChildren<Text>().text = textAnswers[j++];
            answers[2].GetComponentInChildren<Text>().text = textAnswers[j++];
            for (int k = 0; k < 60 && !clickToResult; k++) {
                yield return new WaitForSeconds(0.5f);
            }
        }
        picture.enabled = false;
        subj.text = "Конец теста";
    }

    public void click1()
    {
        answers[0].transform.Find("Check").GetComponent<Image>().enabled = true;
        char[] charsToTrim = { ' ', '\n' };
        int x = System.Int32.Parse(trueAnswers[i].Trim(charsToTrim));
        if (x==1)
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
        char[] charsToTrim = { ' ', '\n' };
        int x = System.Int32.Parse(trueAnswers[i].Trim(charsToTrim));
        if (x == 2)
        {
            PlayerPrefs.SetInt("Answer." + i, 1);
            countOfRate++;
            PlayerPrefs.SetInt("AllTestScore", countOfRate + PlayerPrefs.GetInt("AllTestScore", 0));
        }
        else PlayerPrefs.SetInt("Answer." + i, 0);
        //subj.text = "!" + x + "!" + trueAnswers[i] + "!";
        clickToResult = true;
    }
    public void click3()
    {
        answers[2].transform.Find("Check").GetComponent<Image>().enabled = true;
        char[] charsToTrim = { ' ', '\n' };
        int x = System.Int32.Parse(trueAnswers[i].Trim(charsToTrim));
        if (x == 3)
        {
            PlayerPrefs.SetInt("Answer." + i, 1);
            countOfRate++;
            PlayerPrefs.SetInt("AllTestScore", countOfRate + PlayerPrefs.GetInt("AllTestScore", 0));
        }
        else PlayerPrefs.SetInt("Answer." + i, 0);
        clickToResult = true;

    }

}

