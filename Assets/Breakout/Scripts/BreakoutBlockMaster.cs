using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBlockMaster : MonoBehaviour
{
    public int blocks;

    public void CheckWin()
    {
        if (blocks <= 0)
        {
            GeneralFade.i.FadeOut("SpiderPostTalk");
        }
    }
}
