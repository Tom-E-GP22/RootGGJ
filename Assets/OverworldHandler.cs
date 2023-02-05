using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OverworldHandler : MonoBehaviour
{
    [SerializeField] GeneralFade fadeCS;
    [SerializeField] Animator rootAnim;
    [SerializeField] string[] grow;
    [SerializeField] string[] minigames;
    bool transitionDone;
    int completedMinigames = -1;

    void Awake()
    {
        transitionDone = false;

        if(completedMinigames >= 0)
            rootAnim.SetTrigger(grow[completedMinigames]);
    }

    public void TransitionDone()
    {
        transitionDone = true;
    }

    void Update()
    {
        if(transitionDone)
        {
            completedMinigames++;
            transitionDone = false;
            rootAnim.SetTrigger(grow[completedMinigames]);
            Invoke(nameof(FadeOut), 2f);
        }
    }

    void FadeOut()
    {
        fadeCS.FadeOut(minigames[completedMinigames-1]);
    }
}
