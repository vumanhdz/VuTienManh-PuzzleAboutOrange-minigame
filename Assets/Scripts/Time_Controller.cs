using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TimeText;
    [SerializeField] private GameObject LosePn;
    private float startTime;
    private bool isCounting;
    void Start()
    {
        startTime = Time.time;
        isCounting = true;
    }

    void Update()
    {
        if (!isCounting) return;
        float dem;
        dem = Time.time - startTime;

        int m = (int)dem / 60;
        int s = (int)dem % 60;
        TimeText.text = string.Format("{00:00}:{1:00}", m,s);
        if (s == 45)
        {
            LosePn.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void stopTime()
    {
        isCounting = false; 
    }
}
