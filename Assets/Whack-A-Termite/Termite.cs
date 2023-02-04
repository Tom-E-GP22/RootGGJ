using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Termite : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    private Button button;

    [Header("Animation")]
    private string bonkTrigger = "Bonk";
    private string upTrigger = "Up";

    [Header("Values")]
    private float cooldown = 2f;
    private static int score;
    private int winScore = 25;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponentInParent<Button>();
        button.interactable = false;
        StartCoroutine(PopUp());
    }

    public void Hit()
    {
        animator.SetTrigger(bonkTrigger);
        button.interactable = false;
        score++;

        if (score >= winScore)
        {
            Debug.Log("you win");
        }
        else
        {
            StartCoroutine(PopUp());
        }
    }
    public void Missed()
    {
        animator.SetTrigger(bonkTrigger);
        Debug.Log("u suck");
    }

    private IEnumerator PopUp()
    {
        Debug.Log("up");
        float randomDelay = Random.Range(0.1f, 3f);
        yield return new WaitForSeconds(randomDelay);
        button.interactable = true;
        animator.SetTrigger(upTrigger);
    }
}