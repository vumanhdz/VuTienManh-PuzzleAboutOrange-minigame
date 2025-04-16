using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O1 : MonoBehaviour
{
    public bool isWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("O1"))
        {
            isWin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("O1"))
        {
            isWin = false;
        }
    }
}
