using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Answers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;

    private Action<int> action;

    private AnswerState thisState;

    public void SetAnswerAndGetButton(AnswerState state, string text)
    {
        thisState = state;
      
            
        _answerText.text = text;
        switch (state)
        {
            case AnswerState.Green:
                green.SetActive(true);
                break;
            case AnswerState.Red:
                red.SetActive(true);
                break;
        }
    }

    public void Click()
    {
        GameField.AnswerClick?.Invoke(2);
    }

}
