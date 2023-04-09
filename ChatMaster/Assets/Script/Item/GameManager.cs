using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private GameField _gameField;
    private LvL _lvL;

    private int currentIndex = 0;
    private int currentLvL;
    public static Action<int,string> AnswerClick;

    public GameManager(LvL lvl, GameField gameField)
    {
        _gameField = gameField;
        _lvL = lvl;
        currentLvL = _lvL.lvlNumber;
    }

    public void StartLVL()
    {
        AnswerClick += ActionOrAnswer;
        SetMessageAndAnswer();
    }

    private void SetMessageAndAnswer()
    {
        if (_lvL.CompanionPhrases[currentIndex].companionPhrases.Length != 0)
        {
            foreach (var companionPhrases in _lvL.CompanionPhrases[currentIndex].companionPhrases)
            {
                _gameField.SpawnCompanionMassage(companionPhrases);
            }
        }

        if (_lvL.CompanionPhrases[currentIndex].playerPhrases.Length != 0)
        {
            var CompPhr = _lvL.CompanionPhrases[currentIndex];
            for (var i = 0; i < CompPhr.playerPhrases.Length; i++)
            {
                
                _gameField.SpawnAnswerButton(CompPhr.playerPhrases[i],
                    (AnswerState)CompPhr.colorPlayerPhrases[i],
                    CompPhr.prisePlayerPhrases[i],
                    CompPhr.phraseJumpIndex[i]);
            }
        }
    }
    private void ActionOrAnswer(int num, string text)
    {
        currentIndex = num;
        Debug.Log("Клик сука " + num);
        _gameField.ClearAnswerBox();
        _gameField.SpawnPlayerMassage(text);
        SetMessageAndAnswer();
    }
}