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
    public void StartGame(LvL lvls)
    {
        lvL = lvls;
        moveNext += MoveNext;
        endGame += EndGame;
        ClickAnswer += NextJumpIndex;

        PhrasesConvector(lvL, 0);
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
        
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