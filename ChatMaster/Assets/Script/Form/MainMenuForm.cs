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
    private void Start()
    {
        SetLvL();
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

    public void StarLvl(LvL lvl)
    {
        gameForm.SetActive(true);
        gameDealer.StartGame(lvl);
        ClearLvL();
    }
}
