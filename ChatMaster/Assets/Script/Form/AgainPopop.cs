using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AgainPopop : MonoBehaviour
{
    
    [SerializeField] private Button _again;
  


    public void SetLvl(LvL lvl, MainMenuForm mmf)
    {
        _again.onClick.AddListener(() =>
        {
            if (lvl.lvlNumber <= YandexGame.savesData.progressLvl+1)
            {
                mmf.StarLvl(lvl);
                YandexGame.savesData.progressLvl -= 20;
                YandexGame.SaveProgress();
                gameObject.SetActive(false);
            }
        });
    }
    
}