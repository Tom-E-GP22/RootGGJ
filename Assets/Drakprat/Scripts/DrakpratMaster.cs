using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class DrakpratMaster : MonoBehaviour
{
    private string fail = "You shall speak with respect";

    private System.Random _random = new System.Random();
    private int index = 0;
    private int[] placements = new int[3];
    private bool dead = false;
    private float timer;
    private bool timerOn;

    public float time;
    public float typeSpeed;


    public GameObject fire;
    public Transform[] btnPlacements;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI timeDisplay;
    public Button goodBtn;
    public Button badBtn1;
    public Button badBtn2;
    public TextMeshProUGUI goodBtntext;
    public TextMeshProUGUI badBtn1text;
    public TextMeshProUGUI badBtn2text;

    public Sentance[] dragonSents;
    public Sentance[] goodOptions;
    public Sentance[] badOptions1;
    public Sentance[] badOptions2;

    [System.Serializable]
    public class Sentance
    {
        public string words;
        public int fontsize;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
            placements[i] = i;
        
        index = 0;

        StartCoroutine(Type(dragonSents[index].words));
    }

    private void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            timeDisplay.text = System.Math.Round(timer, 2).ToString();

            if (timer <= 0)
            {
                BadChoice();
            }
        }
    }

    void Shuffle(int[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(0, n);
            int t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }

    private void ShowChoices()
    {
        timerOn = true;
        timeDisplay.gameObject.SetActive(true);
        timer = time;
        goodBtn.transform.position = btnPlacements[placements[0]].position;
        goodBtntext.text = goodOptions[index].words;
        goodBtn.gameObject.SetActive(true);

        badBtn1.transform.position = btnPlacements[placements[1]].position;
        badBtn1text.text = badOptions1[index].words;
        badBtn1.gameObject.SetActive(true);

        badBtn2.transform.position = btnPlacements[placements[2]].position;
        badBtn2text.text = badOptions2[index].words;
        badBtn2.gameObject.SetActive(true);
    }

    IEnumerator Type(string sent)
    {
        foreach (char letter in sent.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        if (!dead)
        {
            Shuffle(placements);
            ShowChoices();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BadChoice()
    {
        fire.SetActive(true);
        textDisplay.text = "";
        StartCoroutine(Type(fail));

        goodBtn.gameObject.SetActive(false);
        badBtn1.gameObject.SetActive(false);
        badBtn2.gameObject.SetActive(false);

        timerOn = false;
        dead = true;
    }

    public void GoodChoice()
    {
        if (index >= 4)
        {
            Debug.Log("Win");
            timerOn = false;
        }
        else
        {
            timerOn = false;
            index++;
            textDisplay.text = "";
            StartCoroutine(Type(dragonSents[index].words));

            goodBtn.gameObject.SetActive(false);
            badBtn1.gameObject.SetActive(false);
            badBtn2.gameObject.SetActive(false);
        }
    }
}
