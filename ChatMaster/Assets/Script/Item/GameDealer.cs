using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameDealer : GameField
{
    [SerializeField] private LevelHeading _headingLvl;
    [SerializeField] private EndGamePopop _endGame;

    protected LvL lvL;

    public static Action<Answer> ClickAnswer;

    public void StartGame(LvL lvl)
    {
        ClearCorrespondenceField();
        lvL = lvl;
        moveNext -= MoveNext;
        endGame -= EndGame;
        ClickAnswer -= NextJumpIndex;
        moveNext += MoveNext;
        endGame += EndGame;
        ClickAnswer += NextJumpIndex;
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
    }

    private IEnumerator ShowEndGame(bool win)
    {
        yield return new WaitForSeconds(1.5f);
        if(win)
        {
            _endGame.gameObject.SetActive(true);
        }
        else
        {
            _headingLvl.gameObject.SetActive(true);
        }
    }
}