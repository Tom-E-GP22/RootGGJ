using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BreakoutPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool move;
    private int dir;

    public float speed;
    public float maxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (move)
            rb.AddForce(transform.up * speed * dir, ForceMode2D.Force);

        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(0, maxSpeed);
        }
        else if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(0, -maxSpeed);
        }
    }

    public void Move(bool _move)
    {
        move = _move;
    }

    public void ChangeDir(int _dir)
    {
        dir = _dir;
    }
}
