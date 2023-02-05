using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralFade : MonoBehaviour
{
    public Transform worm;
    public static GeneralFade i;

    private Animator anim;

    private string sceneName;

    private void Start()
    {
        anim = GetComponent<Animator>();
        i = this;
    }

    public void SetPos()
    {
        transform.position = worm.position;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FadeOut(string scene)
    {
        sceneName = scene;
        anim.SetTrigger("Death");
    }
}
