using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameDealer : GameField
{
    [SerializeField] private LevelHeading _HeadingLvl;

    protected LvL lvL;

    public static Action<Answer> ClickAnswer;

    public void StartGame(LvL lvl)
    {
        lvL = lvl;
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
        _HeadingLvl.gameObject.SetActive(true);
        _HeadingLvl.StartLevelHeading(lvl.taskAtTheLevel);
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
}