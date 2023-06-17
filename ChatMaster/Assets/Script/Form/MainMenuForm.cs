using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

public class MainMenuForm : MonoBehaviour
{
    [SerializeField] private Transform LvLList;
    [SerializeField] protected LvL[] lvLs;
    [SerializeField] protected LVLItem LVLItem;
    [SerializeField] private GameObject gameForm;
    [SerializeField] private GameDealer gameDealer;
    [SerializeField] private GameObject gameForm2;
    [SerializeField] private GameDealer gameDealer2;
    [SerializeField] private Button goGame;
    [SerializeField] private Text coin;
    [SerializeField] private Slider progress;
    [SerializeField] private Button market;
    [SerializeField] private GameObject marketForm;
    [SerializeField] private Button add;
    [SerializeField] private Button gift;
    [SerializeField] private GameObject giftPopup;

    public AgainPopop againPopop;

    protected LvL _currentLevel;
    protected int _passedLevel = 1;

    private const int OnTheMenu = 998;

    public static Action<bool, int?> EndGameFlow;

    private void Start()
    {
        gameForm = Screen.width > Screen.height ? gameForm2 : gameForm;
        gameDealer = Screen.width > Screen.height ? gameDealer2 : gameDealer;
     
        
        add.onClick.AddListener(() =>
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
        gift.gameObject.SetActive(false);
        StartCoroutine(SetGift());

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

    private IEnumerator SetGift()
    {
        yield return new WaitForSeconds(4f);
        
        long time = DateTime.Now.Ticks;
        gift.gameObject.SetActive(time - YandexGame.savesData.lastOpen > 400000000000);
        gift.onClick.AddListener(() =>
        {
            YandexGame.savesData.lastOpen = DateTime.Now.Ticks;
            YandexGame.savesData.coin += 100;
            YandexGame.SaveProgress();
            coin.text = YandexGame.savesData.coin.ToString();
            if (YandexGame.EnvironmentData.promptCanShow)
            {
                YandexGame.PromptShow();
            }

            gift.gameObject.SetActive(false);
            giftPopup.SetActive(true);
        });
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