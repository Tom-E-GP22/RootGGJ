using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatOrb : MonoBehaviour
{
    [SerializeField] GameObject canonBall;

    public Rhythm rhythmCS;
    public Vector2 targetPos;

    public float thisBeat;
    public float speed;

    public enum orbTypes { beat, danger }
    public orbTypes orb;

    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, targetPos) <= 0.5f)
        {
            if (orb == orbTypes.beat)
            {
                Debug.Log("wow");
                Shoot();
                Destroy(gameObject);
            }
            else if (orb == orbTypes.danger)
            {
                Miss();
            }
        }

        if ((Vector2)transform.position == targetPos && orb == orbTypes.beat)
        {
            Miss();
        }
        else if ((Vector2)transform.position == targetPos && orb == orbTypes.danger)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        var instance = Instantiate(canonBall);
        Destroy(instance, 2f);
    }

    void Miss()
    {
        rhythmCS.RemoveHealth();
        Destroy(gameObject);
    }
}
