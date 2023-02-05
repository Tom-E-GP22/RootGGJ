using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameManager : MonoBehaviour
{
    public UnityEvent fadeOut;
    [Header("Values")]
    public int winScore = 25;
    public int score;

    public void ScoreUp()
    {
        score++;
        if(score == winScore)
        {
            fadeOut.Invoke();
        }
    }

    public void RecoverMouse()
    {
        Cursor.visible = true;
    }
}
