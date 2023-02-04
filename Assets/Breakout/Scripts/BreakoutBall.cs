using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutBall : MonoBehaviour
{
    private Vector2 direction;
    private float stuckTimer;
    private bool canPull = true;

    public Transform paddle;
    public GameObject pullBtn;
    public float speed;
    public float pullCooldown;

    void Start()
    {
        direction = Vector2.one.normalized;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        direction.Normalize();
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

    public void Pull()
    {
        if (canPull)
        {
            direction = paddle.position - transform.position;
            direction.Normalize();
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
