using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameField : MonoBehaviour
{
    [SerializeField] private ItemPlayer itemPlayer;
    [SerializeField] private ItemCompanion itemCompanion;
    [SerializeField] private ItemAnswers itemAnswer;
    [SerializeField] private Transform correspondenceField;
    [SerializeField] private Transform selectBox;


    [SerializeField] protected LvL[] lvLs; // Врменно для запуска игры, потом получать в старт поля


    protected Queue<Phrases> ToTheCorrespondenceField;


    void Start()
    {
    }

    protected void PutIntoPlay(ItemBase item)
    {
        var it = Instantiate(item, selectBox);
        switch (it)
        {
            case ItemAnswers answer:
                //it
                break;
            case ItemPlayer player:
                //it
                break;
            case ItemCompanion companion:
                //it
                break;
            default:
                throw new Exception("GameField: PutIntoPlay: ItemBase error cast");
                break;
        }
    }

    private float GetDelay(string message)
    {
        return Random.Range(Constant.DelayTolerances.MaxReadDelay, Constant.DelayTolerances.MinReadDelay) +
               (message.Length * Constant.DelayTolerances.ReadingOneLetter);
    }
}