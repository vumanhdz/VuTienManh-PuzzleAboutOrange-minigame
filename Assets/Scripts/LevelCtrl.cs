using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCtrl : MonoBehaviour
{
    public Button[] lvlBtn;
    public GameObject[] Lv;
    // Start is called before the first frame update
    void Start()
    {

/*                PlayerPrefs.SetInt("LvAt", 2);
        */
        int lvAtt = PlayerPrefs.GetInt("LvAt", 2);
        for (int i = 0; i < lvlBtn.Length; i++)
        {
            if (i + 2 > lvAtt)
            {
                lvlBtn[i].interactable = false;
                Lv[i].SetActive(true);
            }
        }
    }
}
