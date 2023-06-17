using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AgainPopop : MonoBehaviour
{
    
    [SerializeField] private Button _again;
    [SerializeField] private Button _close;
    [SerializeField] private NoMoneyPopup _noMoney;
  


    public void SetLvl(LvL lvl, MainMenuForm mmf)
    {
        _again.onClick.RemoveAllListeners();
        _close.onClick.RemoveAllListeners();
        
        _again.onClick.AddListener(() =>
        {
            if (lvl.lvlNumber <= YandexGame.savesData.progressLvl+1)
            {
                if (YandexGame.savesData.coin >= 20)
                {
                    mmf.StarLvl(lvl);
                    YandexGame.savesData.coin -= 20;
                    YandexGame.SaveProgress();
                    gameObject.SetActive(false);
                }
                else
                {
                    _noMoney.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        });
        _close.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _again.onClick.RemoveAllListeners();
        });
    }
    
}