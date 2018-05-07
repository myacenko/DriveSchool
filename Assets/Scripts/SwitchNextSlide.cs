using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class SwitchNextSlide : MonoBehaviour {
    //URL: https://pdd.am.ru/road-signs/preduprezhdajushhie-znaki/
    public TextAsset spellData;
    public Text subj;
    string[] lines;
    public RawImage rImg;
    string imagePath = "textures";
    Texture2D[] typedTextures;
    void Start()
    {
        Object[] textures = Resources.LoadAll(imagePath);
        typedTextures = new Texture2D[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            typedTextures[i] = (Texture2D)textures[i];
        }
        string fs = spellData.text;
        lines = Regex.Split(fs, "-----");
        StartCoroutine(switcher());

    }


    public IEnumerator switcher()
    {
        subj.text = "Начало занятия";
        for (int i = 0; i < lines.Length; i++)
        {
            subj.text = lines[i];
            if (typedTextures.Length > i)
            {
                rImg.texture = typedTextures[i];
            }
            
            yield return new WaitForSeconds(7.0f);
        }
        rImg.enabled = false;
        subj.text = "Конец занятия";
        
    }
}
    