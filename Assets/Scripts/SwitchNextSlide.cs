using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchNextSlide : MonoBehaviour {

    public Sprite[] images;
    public string[] texts;
    public Image picture;
    public Text subj;
    void Start()
    {
        StartCoroutine(switcher());
    }

    public IEnumerator switcher()
    {
        for(int i = 0; i < images.Length; i++)
        {
            picture.sprite = images[i];
            subj.text = texts[i];
            yield return new WaitForSeconds(15.0f);
        }
    }
}
    