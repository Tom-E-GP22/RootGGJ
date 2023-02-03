using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInput : MonoBehaviour
{
    private bool isMoving;
    private Quaternion endRotation;

    public float distBuffer;
    public float speed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < distBuffer)
        {
            isMoving = true;
        }           

        if (Input.GetMouseButtonUp(0))
            isMoving = false;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            endRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, Time.deltaTime * speed);
        }
    }
}
