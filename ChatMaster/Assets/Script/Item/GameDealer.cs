using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;

public class GameDealer : GameField
{
    
    [SerializeField] protected LvL lvLs; // Врменно для запуска игры, потом получать в старт поля
    void Start()
    {
        moveNext += MoveNext;

        PhrasesConvector(lvLs, 0);
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
        
    }

    private void Ttest(string m)
    {
        Companion it;
        it = new Companion();
        it.Message = m;
        ToTheCorrespondenceField.Enqueue(it);
    }
}