using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class O3 : MonoBehaviour
{
    public bool isWin;
    [SerializeField] private GameObject Winpn;
    private O1 o1;
    private O2 o2;
    private int ScrLv;
    private void Start()
    {
        o1 = FindObjectOfType<O1>();
        o2 = FindObjectOfType<O2>();
        ScrLv = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if (o1.isWin && o2.isWin && isWin)
        {
            Winpn.SetActive(true);
            Time.timeScale = 0f;
            if (ScrLv > PlayerPrefs.GetInt("LvAt"))
            {
                PlayerPrefs.SetInt("LvAt", ScrLv);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("O3"))
        {
            isWin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("O3"))
        {
            isWin = false;
        }
    }
}
