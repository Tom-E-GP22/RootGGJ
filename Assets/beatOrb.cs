using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beatOrb : MonoBehaviour
{
    public Rhythm rhythmCS;
    public Vector2 targetPos;

    public float thisBeat;
    [SerializeField] float speed;


    void Start()
    {
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if(Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, targetPos) <= 0.4f) 
        {
            Debug.Log("wow");
            Destroy(gameObject);
        }
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
