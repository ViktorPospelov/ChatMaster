using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;

public class GameDealer : GameField
{
    
    protected LvL lvLs;
    
    public static Action<Answer> ClickAnswer;
    public void StartGame(LvL lvls)
    {
        lvLs = lvls;
        moveNext += MoveNext;
        endGame += EndGame;
        ClickAnswer += NextJumpIndex;

        PhrasesConvector(lvLs, 0);
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
        
    }

    private void NextJumpIndex(Answer index)
    {
        ClearSelectBox();
        PlayerConvector(index);
        PhrasesConvector(lvLs, index.PhraseJumpIndex);
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