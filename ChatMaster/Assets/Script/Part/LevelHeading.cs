using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelHeading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _formWinPopap;
    [SerializeField] private Button close;

    private void Start()
    {
        close.onClick.AddListener(() =>
        {
            close.onClick.RemoveAllListeners();
            this.gameObject.SetActive(false);
        });
    }

    public void StartLevelHeading(string message)
    {
        _formWinPopap.text = message;
    }
}
