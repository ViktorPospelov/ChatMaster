using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;


public class ItemAnswers : ItemBase
{
    
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    [SerializeField] private Button button;


    private AnswerState _thisState;
    private int _thisNextIndex;

    public void SetAnswer(Answer item)
    {
        if (item.PhraseJumpIndex > 55)
        {
            if (item.Message == "")
            {
                GameField.endGame?.Invoke(item.PhraseJumpIndex==999);
                Destroy(this.gameObject);
                return;
            }
        }
        _thisState = (AnswerState)item.ColorPlayerPhrases;
        SetMessage(item.Message);
        button.onClick.AddListener(() =>
        {
            GameDealer.ClickAnswer?.Invoke(item);
        });
        
        SetColor();

        _thisNextIndex = item.PhraseJumpIndex;
    }

    private void SetColor()
    {
        red.SetActive(false);
        green.SetActive(false);
        switch (_thisState)
        {
            case AnswerState.Green:
                green.SetActive(true);
                break;
            case AnswerState.Red:
                red.SetActive(true);
                break;
        }
    }
}
