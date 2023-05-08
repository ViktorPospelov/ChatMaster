using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

public class GameDealer : GameField
{
    [SerializeField] private LevelHeading _headingLvl;
    [SerializeField] private EndGamePopop _endGame;
    [SerializeField] private Button _toMeButton;

    protected LvL lvL;

    public static Action<Answer> ClickAnswer;

    private const int OnTheMenu = 998;

    private void Awake()
    {
        moveNext += MoveNext;
        endGame += EndGame;
        ClickAnswer += NextJumpIndex;
        _toMeButton.onClick.AddListener(() =>
        {
            MainMenuForm.EndGameFlow?.Invoke(false, OnTheMenu);
            ClearCorrespondenceField();
            ClearSelectBox();
            ToTheCorrespondenceField.Clear();
            _endGame.gameObject.SetActive(false);
            _headingLvl.gameObject.SetActive(false);
        });
    }

    public void StartGame(LvL lvl)
    {
        ClearSelectBox();
        ClearCorrespondenceField();
        lvL = lvl;

        SetAvatarToLvl(lvl);
        SetHeading(lvl);

        PhrasesConvector(lvL, 0);
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
    }

    private void SetHeading(LvL lvl)
    {
        _headingLvl.gameObject.SetActive(true);
        _headingLvl.StartLevelHeading(lvl.taskAtTheLevel);
    }

    private void SetAvatarToLvl(LvL lvl)
    {
        _avatar.SetAvatar(lvl.CompanionName);
        _companionName.text = lvl.CompanionName[0];
    }

    private void NextJumpIndex(Answer index)
    {
        ClearSelectBox();
        PlayerConvector(index);
        PhrasesConvector(lvL, index.PhraseJumpIndex);
        MoveNext();
    }

    protected override void EndGame(bool win)
    {
        base.EndGame(win);
        StartCoroutine(ShowEndGame(win));
        if (YandexGame.savesData.progressLvl <= lvL.lvlNumber)
        {
            YandexGame.savesData.progressLvl = lvL.lvlNumber;
            YandexGame.SaveProgress();
        }
    }

    private IEnumerator ShowEndGame(bool win)
    {
        yield return new WaitForSeconds(1.5f);
        _endGame.gameObject.SetActive(true);
        _endGame.SetGameState(win);
    }
}