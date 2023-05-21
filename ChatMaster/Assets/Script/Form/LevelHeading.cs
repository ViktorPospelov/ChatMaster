using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelHeading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _formWinPopap;
    [SerializeField] private Button close;

    private void StartLisen()
    {
        close.onClick.RemoveAllListeners();
        GameDealer.ClickAnswer -= Close;
        
        close.onClick.AddListener(() =>
        {
            close.onClick.RemoveAllListeners();
            this.gameObject.SetActive(false);
        });
        GameDealer.ClickAnswer += Close;
    }

    private void Close(Answer a)
    {
        this.gameObject.SetActive(false);
    }
    public void StartLevelHeading(string message)
    {
        _formWinPopap.text = message;
        StartLisen();
    }
}
