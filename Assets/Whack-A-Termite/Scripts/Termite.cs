using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Termite : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] AudioClip termiteLaugh;
    MinigameManager gameManager;
    private Animator animator;
    private Button button;

    [Header("Animation")]
    private string bonkTrigger = "Bonk";
    private string upTrigger = "Up";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponentInParent<Button>();
        gameManager = GetComponentInParent<MinigameManager>();
        button.interactable = false;
        StartCoroutine(PopUp());
    }

    public void Hit()
    {
        animator.SetTrigger(bonkTrigger);
        button.interactable = false;
        gameManager.score++;

        if (gameManager.score >= gameManager.winScore)
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
        GetComponentInParent<AudioSource>().PlayOneShot(termiteLaugh);
        animator.SetTrigger(bonkTrigger);
        Debug.Log("u suck");
        StartCoroutine(PopUp());
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