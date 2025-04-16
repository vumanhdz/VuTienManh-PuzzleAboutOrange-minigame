using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UICtrl : MonoBehaviour
{
    [SerializeField] private GameObject PausePn;
    private int ScrLv;
    private void Start()
    {
        ScrLv = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void Pause()
    {
        PausePn.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        PausePn.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1.0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuLv");
        Time.timeScale = 1.0f;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Lv" + levelIndex);
        Time.timeScale = 1.0f;
    }
    public void Next_Level()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            Home();
        }
        else
        {
            SceneManager.LoadScene(ScrLv);
            Time.timeScale = 1.0f;
        }
    }
}
