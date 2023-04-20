using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;

public class GameDealer : GameField
{
    void Start()
    {
        Ttest("Привет игра, это я твой разрабочик");
        Ttest(" Привет игра, это я твой разрабочик Привет игра, это я твой разрабочик Привет игра, это я твой разрабочик Привет игра, это я твой разрабочик Привет игра, это я твой разрабочик");
        Ttest("Привет игра, это я твой разрабочик");
        Ttest("Привет игра, это я твой разрабочик");
        Ttest("Привет игра, это я твой разрабочик");


        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
        moveNext += MoveNext;
    }

    private void Ttest(string m)
    {
        Companion it;
        it = new Companion();
        it.Message = m;
        ToTheCorrespondenceField.Enqueue(it);
    }
}