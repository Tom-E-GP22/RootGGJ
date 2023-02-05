using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class OverworldHandler : MonoBehaviour
{
    [SerializeField] GeneralFade fadeCS;
    [SerializeField] Animator rootAnim;
    [SerializeField] string[] grow;
    [SerializeField] string[] minigames;
    bool transitionDone;

    string minigameKey = "completedMinigames";
    int completedMinigames = -1;
    int minValue;

    void Awake()
    {
        if(!PlayerPrefs.HasKey(minigameKey))
            PlayerPrefs.SetInt(minigameKey, minValue);
        else
            completedMinigames = PlayerPrefs.GetInt(minigameKey);

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
            PlayerPrefs.SetInt(minigameKey, completedMinigames);

            rootAnim.SetTrigger(grow[completedMinigames]);
            Invoke(nameof(FadeOut), 3.5f);
        }
    }

    void FadeOut()
    {
        fadeCS.FadeOut(minigames[completedMinigames]);
    }
}
