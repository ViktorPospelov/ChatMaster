using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MainMenuForm : MonoBehaviour
{
    [SerializeField] private Transform LvLList;
    [SerializeField] protected LvL[] lvLs;
    [SerializeField] protected LVLItem LVLItem;
    [SerializeField] private GameObject gameForm;
    [SerializeField] private GameDealer gameDealer;
    [SerializeField] private Button goGame;
    [SerializeField] private Text coin;
    [SerializeField] private Slider progress;

    protected LvL _currentLevel;
    protected int _passedLevel = 1;

    private const int OnTheMenu = 998;

    public static Action<bool, int?> EndGameFlow;

    private void Start()
    {
        EndGameFlow += NextLevel;
        
        _currentLevel = lvLs[_passedLevel-1];
        goGame.onClick.AddListener(() =>
        { 
            StarLvl(_currentLevel);
        });
        YandexGame.GetDataEvent += UbdateSaves;
        
    }

    private void UbdateSaves()
    {
        coin.text = YandexGame.savesData.coin.ToString();
        if (LvLList.transform.childCount<=1)
        {
            SetLvL();
        }
        _passedLevel = YandexGame.savesData.progressLvl;
        SetProgress();
    }

    private void SetProgress()
    {
        progress.maxValue = lvLs.Length;
        progress.value = YandexGame.savesData.progressLvl;
    }

    private void SetLvL()
    {
        foreach (var lvl in lvLs)
        {
            var it = Instantiate(LVLItem, LvLList);
            it.SetLvl(lvl, this);
        }
    }

    private void ClearLvL()
    {
        foreach (Transform lvl in LvLList.transform)
        {
            Destroy(lvl.gameObject);
        }
    }

    private void NextLevel(bool nextLevel, int? addCoin)
    {
        coin.text = YandexGame.savesData.coin.ToString();
        if (_passedLevel == lvLs.Length)
        {
            Debug.Log("Всё прошел красавчик");
            gameForm.SetActive(false);
            return;
        }

        if (addCoin == OnTheMenu)
        {
            gameForm.SetActive(false);
            return;
        }

        if (nextLevel)
        {
            _passedLevel++;
            _currentLevel = lvLs[_passedLevel-1];
        }
        gameDealer.StartGame(_currentLevel);
        ClearLvL();
        SetLvL();
        SetProgress();
    }

    public void StarLvl(LvL lvl)
    {
        ClearLvL();
        _currentLevel = lvl;
        gameForm.SetActive(true);
        gameDealer.StartGame(lvl);
        _passedLevel = lvl.lvlNumber;
        SetLvL();
    }
}