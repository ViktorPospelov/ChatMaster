using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public abstract class GameField : MonoBehaviour
{
    [SerializeField] protected ItemPlayer itemPlayer;
    [SerializeField] protected ItemCompanion itemCompanion;
    [SerializeField] protected ItemAnswers itemAnswer;
    [SerializeField] protected Transform correspondenceField;
    [SerializeField] protected Transform selectBox;


    [SerializeField] protected LvL[] lvLs; // Врменно для запуска игры, потом получать в старт поля


    protected Queue<BaseGameItem> ToTheCorrespondenceField;


    protected void PutIntoPlay(BaseGameItem item)
    {
        switch (item)
        {
            case Answer answer:
                var insertAnswer = Instantiate(itemAnswer, selectBox);
                ProcessObject(answer, insertAnswer);
                break;
            case Player player:
                var insertPlayer = Instantiate(itemPlayer, correspondenceField);
                ProcessObject(player, insertPlayer);
                break;
            case Companion companion:
                var insertCompanion = Instantiate(itemCompanion, correspondenceField);
                ProcessObject(companion, insertCompanion);
                break;
            default:
                throw new Exception("GameField: PutIntoPlay: ItemBase error cast");
                break;
        }
    }

    protected float GetDelay(string message)
    {
        return Random.Range(Constant.DelayTolerances.MaxReadDelay, Constant.DelayTolerances.MinReadDelay) +
               (message.Length * Constant.DelayTolerances.ReadingOneLetter);
    }

    protected void ProcessObject(Answer item, ItemAnswers insert)
    {
    }

    protected void ProcessObject(Player item, ItemPlayer insert)
    {
    }

    protected void ProcessObject(Companion item, ItemCompanion insert)
    {
        insert.SetMessage(item.Message);
    }

    protected void PhrasesConvector(Phrases phrases)
    {
        foreach (var companion in phrases.companionPhrases)
        {
        }
    }
}