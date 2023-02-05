using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beatOrb : MonoBehaviour
{
    public Rhythm rhythmCS;
    public Vector2 targetPos;
    private Vector2 spawnPos;

    public float thisBeat;


    void Start()
    {
        spawnPos = transform.position;
    }

    void Update()
    {
        float step = 2.5f * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if((Vector2)transform.position == targetPos)
        {
            Miss();
        }
    }

    void Miss()
    {
        Debug.Log("you're shit");
        Destroy(gameObject);
    }
}
