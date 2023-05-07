using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EndGamePopop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _formWinPopap;
    [SerializeField] private Button _nextLvl;
    [SerializeField] private Button _addCoin;
    private const int StandartRevard = 10 ;
    private bool _endGame;
    private void Start()
    {
       _nextLvl.onClick.AddListener(() =>
       {
           MainMenuForm.EndGameFlow?.Invoke(true,StandartRevard);
           gameObject.SetActive(false);
           RemoveListener();
       });
       _addCoin.onClick.AddListener(() =>
       {
           YandexGame.RewVideoShow(20);
           MainMenuForm.EndGameFlow?.Invoke(true,StandartRevard*2); // завершить показ рекламы
           gameObject.SetActive(false); // завершить показ рекламы
           RemoveListener(); // завершить показ рекламы
       });
    }

    public void SetGameState(bool win)
    {
        _endGame = win;
        _formWinPopap.text = win ? "Победа!" : "Провалено!";
        _formWinPopap.color = win ? Color.green : Color.red;
    }
    

    private void RemoveListener()
    {
        _addCoin.onClick.RemoveAllListeners();
        _nextLvl.onClick.RemoveAllListeners();
    }

}
