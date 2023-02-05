using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DrakpratMaster : MonoBehaviour
{
    private int index = 0;
    private Button[] buttons;

    public Button goodBtn;
    public Button badBtn1;
    public Button badBtn2;

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
        
    }
}
