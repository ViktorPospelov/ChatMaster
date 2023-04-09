using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class AnswersP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    [SerializeField] private Button button;
 

    private Action<int,string> _action;

    private AnswerState _thisState;

    private int _answerIndex = 0;
    private int _prise = 0;

    private void Start()
    {
        _action = GameManager.AnswerClick;
        button.onClick.AddListener(() =>
        {
            _action?.Invoke(_answerIndex,_answerText.text);
            Debug.Log("Есть клик");
        });
    }

    public void SetAnswer(int prise,AnswerState state, string text, int answerIndex)
    {
        _prise = prise;
        _thisState = state;

        _answerIndex = answerIndex;
        
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
        
    }
}
