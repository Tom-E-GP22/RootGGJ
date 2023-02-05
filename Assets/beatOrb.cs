using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beatOrb : MonoBehaviour
{
    [SerializeField] GameObject canonBall;

    public Rhythm rhythmCS;
    public Vector2 targetPos;

    public float thisBeat;
    public float speed;


    void Start()
    {
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if(Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, targetPos) <= 0.5f) 
        {
            Debug.Log("wow");
            Shoot();
            Destroy(gameObject);
        }
        if((Vector2)transform.position == targetPos)
        {
            Miss();
        }
    }

    void Shoot()
    {
        var instance = Instantiate(canonBall);
        Destroy(instance, 2f);
    }

    void Miss()
    {
        Debug.Log("you're shit");
        Destroy(gameObject);
    }
}
