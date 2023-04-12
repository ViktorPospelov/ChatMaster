using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager
{
    private GameField _gameField;
    private LvL _lvL;

    private int currentIndex = 0;
    private int currentLvL;
    public static Action<int, string> AnswerClick;

    public LvlState LvlState;


    public GameManager(LvL lvl, GameField gameField)
    {
        _gameField = gameField;
        _lvL = lvl;
        currentLvL = _lvL.lvlNumber;
    }
}