using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCamera : MonoBehaviour
{
    public float speed;

    private void OnEnable()
    {
        WormRock.OnWormDeath += WormDeath;
    }

    private void OnDisable()
    {
        WormRock.OnWormDeath -= WormDeath;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void WormDeath()
    {
        speed = 0;
    }
}
