using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;

public class GameDealer : GameField
{
    
    protected LvL lvL;
    
    public static Action<Answer> ClickAnswer;
    public void StartGame(LvL lvl)
    {
        lvL = lvl;
        moveNext += MoveNext;
        endGame += EndGame;
        ClickAnswer += NextJumpIndex;
        SetAvatarToLvl(lvl);

        PhrasesConvector(lvL, 0);
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
        
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

    private void Ttest(string m)
    {
        Companion it;
        it = new Companion();
        it.Message = m;
        ToTheCorrespondenceField.Enqueue(it);
    }
}