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

    public void StartLVL()
    {
        AnswerClick += ActionOrAnswer;
        SetMessageAndAnswer();
        LvlState = LvlState.Game;
    }

    private void SetMessageAndAnswer()
    {
        if (_lvL.CompanionPhrases[currentIndex].companionPhrases.Length != 0)
        {
            _gameField.SpawnCompanionMassage(_lvL.CompanionPhrases[currentIndex].companionPhrases);
        }

        // if (currentIndex > 55) currentIndex = 0;
        if (_lvL.CompanionPhrases[currentIndex].playerPhrases.Length != 0)
        {
            var CompPhr = _lvL.CompanionPhrases[currentIndex];
            for (var i = 0; i < CompPhr.playerPhrases.Length; i++)
            {
                if (CompPhr.phraseJumpIndex[i] > 55)
                {
                    LvlState = CompPhr.phraseJumpIndex[i] == 999 ? LvlState.Win : LvlState.Lose;
                    if (CompPhr.playerPhrases[0] == "") return; // переделать победу
                }
                ///пределать
            }
        }
    }

    private IEnumerator AnswerTimer(Phrases CompPhr, int i)
    {
        while (GameField.gameManager.LvlState != LvlState.Game)
        {
            yield return new WaitForSeconds(1f);
        }
        _gameField.SpawnAnswerButton(CompPhr.playerPhrases[i],
            (AnswerState)CompPhr.colorPlayerPhrases[i],
            CompPhr.prisePlayerPhrases[i],
            CompPhr.phraseJumpIndex[i]);
        
    }

    private void ActionOrAnswer(int num, string text)
    {
        currentIndex = num;

        _gameField.ClearAnswerBox();
        _gameField.SpawnPlayerMassage(text);
        SetMessageAndAnswer();
    }
}