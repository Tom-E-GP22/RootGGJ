using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutBall : MonoBehaviour
{
    private Vector2 direction;
    private float stuckTimer;
    private bool canPull = true;
    private LineRenderer lineRenderer;
    private bool pulling;

    public Transform paddle;
    public GameObject pullBtn;
    public float speed;
    public float pullCooldown;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        direction = Vector2.one.normalized;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void Update()
    {
        if (pulling)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, paddle.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        direction.Normalize();

        pulling = false;
        lineRenderer.enabled = false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        stuckTimer += Time.deltaTime;

        if (stuckTimer > 1)
        {
            direction = -direction;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        stuckTimer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            GeneralFade.i.FadeOut("Breakout");
        }
    }

    public void Pull()
    {
        if (canPull)
        {
            direction = paddle.position - transform.position;
            direction.Normalize();
            lineRenderer.enabled = true;
            pulling = true;
            StartCoroutine("StartCooldown");
        }
    }

    public IEnumerator StartCooldown()
    {
        canPull = false;
        pullBtn.SetActive(false);
        yield return new WaitForSeconds(pullCooldown);
        canPull = true;
        pullBtn.SetActive(true);
    }
}
