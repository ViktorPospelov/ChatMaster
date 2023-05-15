using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LVLItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LvlName;
    [SerializeField] private GameObject complete;
    [SerializeField] private GameObject lvlGo;
    [SerializeField] private Button beginLvl;

    [SerializeField] private static AgainPopop againPopop;

    private void Clear()
    {
        LvlName.text = "";
        complete.SetActive(false);
        lvlGo.SetActive(false);
    }

    public void SetLvl(LvL lvl, MainMenuForm mmf)
    {
        Clear();
        LvlName.text = $"{lvl.lvlNumber} {lvl.taskAtTheLevel}";
        
        mmf.againPopop.SetLvl(lvl,mmf);
        beginLvl.onClick.AddListener(() =>
        {
            if (lvl.lvlNumber == YandexGame.savesData.progressLvl+1)
            {
                mmf.StarLvl(lvl);
            }
            else if (lvl.lvlNumber <= YandexGame.savesData.progressLvl)
            {
                mmf.againPopop.gameObject.SetActive(true);
            }
        });
        complete.SetActive(lvl.lvlNumber <= YandexGame.savesData.progressLvl);
        lvlGo.SetActive(lvl.lvlNumber == YandexGame.savesData.progressLvl+1);

        if (lvl.lvlNumber > YandexGame.savesData.progressLvl+1)
        {
            LvlName.color = Color.gray;
        }
        else
        {
            LvlName.color = Color.black;
        }
    }
    
}