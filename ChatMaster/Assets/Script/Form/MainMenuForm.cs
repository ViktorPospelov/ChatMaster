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
        
    public static Action<bool, int> EndGameFlow;
    private void Start()
    {
        SetLvL();
        EndGameFlow += NextLevel;

        _currentLevel = lvLs[0];
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

    private void NextLevel(bool  nextLevel, int addCoin)
    {
        gameDealer.StartGame(_currentLevel);
    }
    public void StarLvl(LvL lvl)
    {
        _currentLevel = lvl;
        gameForm.SetActive(true);
        gameDealer.StartGame(lvl);
        ClearLvL();
    }
}
