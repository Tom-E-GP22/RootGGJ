using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Win");
    }
}