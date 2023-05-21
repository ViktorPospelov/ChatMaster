using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MainMenuForm : MonoBehaviour
{
    [SerializeField] private Transform LvLList;
    [SerializeField] protected LvL[] lvLs;
    [SerializeField] protected LVLItem LVLItem;
    [SerializeField] private GameObject gameForm;
    [SerializeField] private GameDealer gameDealer;
    [SerializeField] private Button goGame;
    [SerializeField] private Text coin;
    [SerializeField] private Slider progress;
    [SerializeField] private Button market;
    [SerializeField] private GameObject marketForm;
    [SerializeField] private Button Add;
    
    public AgainPopop againPopop;

    protected LvL _currentLevel;
    protected int _passedLevel = 1;

    private const int OnTheMenu = 998;

    public static Action<bool, int?> EndGameFlow;

    private void Start()
    {
        Add.onClick.AddListener(() =>
        {
            YandexGame.savesData.coin += 100;
            YandexGame.SaveProgress();
            coin.text = YandexGame.savesData.coin.ToString();
            if (YandexGame.EnvironmentData.promptCanShow)
            {
                YandexGame.PromptShow();
            }
        });
       
        
        EndGameFlow += NextLevel;

        _currentLevel = lvLs[_passedLevel - 1];
        goGame.onClick.AddListener(() =>
        {
            if (YandexGame.savesData.progressLvl == lvLs.Length)
            {
                StarLvl(lvLs.Last());
            }
            else
            {
                StarLvl(lvLs[YandexGame.savesData.progressLvl]);
            }
        });
        market.onClick.AddListener(() => { marketForm.SetActive(true); });
        YandexGame.GetDataEvent += UbdateSaves;
        YandexGame.PurchaseSuccessEvent += ByCoin;
    }

    private void ByCoin(string id)
    {
        YandexGame.savesData.coin += Convert.ToInt32(id);
        YandexGame.SaveProgress();
        UbdateSaves();
    }

    private void UbdateSaves()
    {
        coin.text = YandexGame.savesData.coin.ToString();
        if (LvLList.transform.childCount <= 1)
        {
            SetLvL();
        }
       
        _passedLevel = YandexGame.savesData.progressLvl;
        SetProgress();
    }

    private void SetProgress()
    {
        progress.maxValue = lvLs.Length;
        progress.value = YandexGame.savesData.progressLvl;
    }

    private void SetLvL()
    {
        foreach (var lvl in lvLs)
        {
            var it = Instantiate(LVLItem, LvLList);
            it.SetLvl(lvl, this);
        }
    }

    private void ClearLvL()
    {
        foreach (Transform lvl in LvLList.transform)
        {
            Destroy(lvl.gameObject);
        }
    }

    private void NextLevel(bool nextLevel, int? addCoin)
    {
        coin.text = YandexGame.savesData.coin.ToString();
        if (_passedLevel == lvLs.Length)
        {
            Debug.Log("Всё прошел красавчик");
            gameForm.SetActive(false);
            return;
        }

        if (addCoin == OnTheMenu)
        {
            gameForm.SetActive(false);
            return;
        }

        if (nextLevel)
        {
            _passedLevel++;
            _currentLevel = lvLs[_passedLevel - 1];
        }

        gameDealer.StartGame(_currentLevel);
        ClearLvL();
        SetLvL();
        SetProgress();
    }

    public void StarLvl(LvL lvl)
    {
        ClearLvL();
        _currentLevel = lvl;
        gameForm.SetActive(true);
        gameDealer.StartGame(lvl);
        _passedLevel = lvl.lvlNumber;
        SetLvL();
    }
}