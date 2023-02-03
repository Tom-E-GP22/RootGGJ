using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public Transform wheel;
    public float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        WormRock.OnWormDeath += WormDeath;
    }

    private void OnDisable()
    {
        WormRock.OnWormDeath -= WormDeath;
    }

    private void Update()
    {
        transform.rotation = wheel.rotation;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void WormDeath()
    {
        speed = 0;
    }
}
