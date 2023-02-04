using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomCursor : MonoBehaviour
{
    private Vector2 cursorPos;
    private Animator animator;

    private void Awake()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    void OnMouseDown()
    {
        animator.SetTrigger("Bonk");
    }
}
