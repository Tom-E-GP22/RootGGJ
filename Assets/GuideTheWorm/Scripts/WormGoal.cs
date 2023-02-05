using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGoal : MonoBehaviour
{
    public WormController worm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        worm.speed = 0;
        GeneralFade.i.FadeOut("WormPostTalk");
    }
}
