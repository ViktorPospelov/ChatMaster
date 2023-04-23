using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LVLItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LvlName;
    [SerializeField] private GameObject complete;
    [SerializeField] private GameObject lvlGo;
    [SerializeField] private Button beginLvl;

    private void Clear()
    {
        LvlName.text = "";
        complete.SetActive(false);
        lvlGo.SetActive(false);
    }

    public void SetLvl(LvL lvl,MainMenuForm mmf)
    {
        Clear();
        LvlName.text = $"{lvl.lvlNumber} {lvl.taskAtTheLevel}";
        beginLvl.onClick.AddListener(() =>
        {
            mmf.StarLvl(lvl);
        });
    }

    private void SetColorGray()
    {
        LvlName.color = Color.gray;
    }
}
