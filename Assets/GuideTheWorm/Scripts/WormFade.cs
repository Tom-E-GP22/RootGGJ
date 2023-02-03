using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormFade : MonoBehaviour
{
    public Transform worm;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        WormRock.OnWormDeath += WormDeath;
    }

    private void OnDisable()
    {
        WormRock.OnWormDeath -= WormDeath;
    }

    public void SetPos()
    {
        transform.position = worm.position;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void WormDeath()
    {
        anim.SetTrigger("Death");
    }
}
