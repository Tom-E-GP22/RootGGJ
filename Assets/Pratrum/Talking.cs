using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Talking : MonoBehaviour
{
    public Sentance[] sentances;
    public TextMeshProUGUI textDisplay;
    public Image image;

    public string nextScene;
    public float typeSpeed;

    private int index;
    private bool isTyping;

    [System.Serializable]
    public class Sentance
    {
        public string words;
        public Sprite image;
    }

    public void Start()
    {
        index = 0;
        StartCoroutine(Type(sentances[index].words));
    }

    public void Update()
    {
        if (Input.anyKeyDown && !isTyping)
        {
            NextSentance();
        }
    }

    private void NextSentance()
    {
        isTyping = true;

        if (index < sentances.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type(sentances[index].words));
        }
        else
        {
            GeneralFade.i.FadeOut(nextScene);
        }
    }

    IEnumerator Type(string sent)
    {
        image.GetComponent<Image>().sprite = sentances[index].image;
        isTyping = true;

        foreach (char letter in sent.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }
}
