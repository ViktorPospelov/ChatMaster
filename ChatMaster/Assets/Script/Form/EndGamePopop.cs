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
    [SerializeField] private Button _again;
    [SerializeField] private Button _menu;
    [SerializeField] private ParticleSystem _showFireworks;
    [SerializeField] private GameObject coin;


    private const int StandartRevard = 10;
    private const int OnTheMenu = 998;

    private bool _endGame;

    public void SetGameState(bool win)
    {
        _endGame = win;
        if (_endGame)
        {
            _addCoin.gameObject.SetActive(true);
            _nextLvl.gameObject.SetActive(true);
        }
        else
        {
            _again.gameObject.SetActive(true);
            _menu.gameObject.SetActive(true);
        }

        _formWinPopap.text = _endGame ? "Победа!" : "Провалено!";
        _formWinPopap.color = _endGame ? Color.green : Color.red;
        StartForm();
        coin.SetActive(_endGame);
    }

    private void StartForm()
    {
        YandexGame.RewardVideoEvent += AfterTheAdv;
        _nextLvl.onClick.AddListener(() =>
        {
            MainMenuForm.EndGameFlow?.Invoke(true, StandartRevard);
            RemoveListenerAndClose();
            YandexGame.savesData.coin += StandartRevard;
            YandexGame.SaveProgress();
        });
        _addCoin.onClick.AddListener(() => { YandexGame.RewVideoShow(StandartRevard * 2); });
        _again.onClick.AddListener(() =>
        {
            MainMenuForm.EndGameFlow?.Invoke(false, null);
            RemoveListenerAndClose();
        });
        _menu.onClick.AddListener(() =>
        {
            MainMenuForm.EndGameFlow?.Invoke(false, OnTheMenu);
            RemoveListenerAndClose();
        });
        if (_endGame) _showFireworks.Play();
    }

    private void AfterTheAdv(int coin)
    {
        MainMenuForm.EndGameFlow?.Invoke(true, coin);
        YandexGame.savesData.coin += coin;
        YandexGame.SaveProgress();

        RemoveListenerAndClose();
    }


    private void RemoveListenerAndClose()
    {
        _addCoin.onClick.RemoveAllListeners();
        _again.onClick.RemoveAllListeners();
        _menu.onClick.RemoveAllListeners();
        _nextLvl.onClick.RemoveAllListeners();
        _addCoin.gameObject.SetActive(false);
        _again.gameObject.SetActive(false);
        _menu.gameObject.SetActive(false);
        _nextLvl.gameObject.SetActive(false);
        YandexGame.RewardVideoEvent -= AfterTheAdv;
        gameObject.SetActive(false);
    }
}