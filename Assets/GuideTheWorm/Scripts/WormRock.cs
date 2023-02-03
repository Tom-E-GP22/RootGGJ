using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormRock : MonoBehaviour
{
    public static Action OnWormDeath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnWormDeath();
    }
}
