using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuForm : MonoBehaviour
{
    [SerializeField] private Transform LvLList;
    [SerializeField] protected LvL[] lvLs;
    [SerializeField] protected LVLItem LVLItem;
    [SerializeField] private GameObject gameForm;
    [SerializeField] private GameDealer gameDealer;

    protected LvL _currentLevel;
    protected int _passedLevel = 0;

    private const int OnTheMenu = 998;

    public static Action<bool, int?> EndGameFlow;

    private void Start()
    {
        SetLvL();
        EndGameFlow += NextLevel;
        _passedLevel = 0;
        _currentLevel = lvLs[_passedLevel];
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
        if (_passedLevel + 1 == lvLs.Length)
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
            _currentLevel = lvLs[_passedLevel];
        }
        gameDealer.StartGame(_currentLevel);
    }

    public void StarLvl(LvL lvl)
    {
        ClearLvL();
        _currentLevel = lvl;
        gameForm.SetActive(true);
        gameDealer.StartGame(lvl);
        SetLvL();
    }
}