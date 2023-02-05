using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBlock : MonoBehaviour
{
    public BreakoutBlockMaster Master;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Master.blocks--;
            Master.CheckWin();
            Destroy(gameObject);
        }
    }
}
