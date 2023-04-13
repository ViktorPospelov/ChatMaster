using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager
{
    private GameField _gameField;
    private LvL _lvL;

    private int _currentIndex = 0;
    private int _currentLvL;
    public static Action<int, string> AnswerClick;

    public LvlState LvlState;

    private Queue<Phrases> _toThePlayingField;


    public GameManager(LvL lvl, GameField gameField)
    {
        _gameField = gameField;
        _lvL = lvl;
        _currentLvL = _lvL.lvlNumber;
    }

    private void MoveNext()
    {
        var ph =_toThePlayingField.Dequeue();
    }
    
    private void AddPhrasesToQueue( Phrases phrases)
    {
        _toThePlayingField.Enqueue(phrases);
    }
    
}