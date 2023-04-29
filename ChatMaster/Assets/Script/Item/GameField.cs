using System;
using System.Collections;
using System.Collections.Generic;
using Script.Item.FieldObjects;
using TMPro;
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

    [SerializeField] protected AvatarForm _avatar;
    [SerializeField] protected TextMeshProUGUI _companionName;

    protected Queue<BaseGameItem> ToTheCorrespondenceField = new Queue<BaseGameItem>();
    private ItemBase _lastItem;
    public static Action moveNext;
    public static Action<bool> endGame;

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
                var companionItem = Instantiate(itemCompanion, correspondenceField);
                ProcessObject(companion, companionItem);
                break;
            default:
                throw new Exception("GameField: PutIntoPlay: BaseGameItem error cast");
        }
    }

    protected void ClearCorrespondenceField()
    {
        foreach (Transform it in correspondenceField)
        {
            Destroy(it.gameObject);
        }
    }

    protected float GetDelay(string message)
    {
        if (message == "MoveNext")
            return Random.Range(Constant.DelayTolerances.MinBetweenMessages,
                Constant.DelayTolerances.MaxBetweenMessages);

        return Random.Range(Constant.DelayTolerances.MaxReadDelay, Constant.DelayTolerances.MinReadDelay) +
               (message.Length * Constant.DelayTolerances.ReadingOneLetter);
    }

    protected void ProcessObject(Answer item, ItemAnswers insert)
    {
        insert.SetAnswer(item);
        _lastItem = insert;
    }

    protected void ProcessObject(Player item, ItemPlayer insert)
    {
        insert.SetPlayerMessage(item.Message, item.Name);
        _lastItem = insert;
    }

    protected void ProcessObject(Companion item, ItemCompanion insert)
    {
        insert.SetMessage(item.Message, GetDelay(item.Message), item.Name);
        _lastItem = insert;
    }

    protected void MoveNext()
    {
        if (_lastItem is not null) _lastItem.transform.localScale += new Vector3(0, 0.001f, 0);
        if (ToTheCorrespondenceField.Count != 0)
        {
            StartCoroutine(DelayNext(ToTheCorrespondenceField.Peek() is Answer||ToTheCorrespondenceField.Peek() is Player));
        }
    }

    private IEnumerator DelayNext(bool isAnswer)
    {
        if (!isAnswer) yield return new WaitForSeconds(GetDelay("MoveNext"));
        PutIntoPlay(ToTheCorrespondenceField.Dequeue());
    }

    protected void PhrasesConvector(LvL lvl, int index)
    {
        if (index > 55)
        {
            EndGame(index == 999);
            return;
        }
        
        var phrases = lvl.CompanionPhrases[index];
        foreach (var companionPhrases in phrases.companionPhrases)
        {
            var item = new Companion();
            item.Message = companionPhrases;
            item.Name = lvl.CompanionName;
            ToTheCorrespondenceField.Enqueue(item);
        }

        for (var i = 0; i < phrases.playerPhrases.Length; i++)
        {
            var item = new Answer();
            item.Message = phrases.playerPhrases[i];
            item.PhraseJumpIndex = phrases.phraseJumpIndex[i];
            item.PrisePlayerPhrases = phrases.prisePlayerPhrases[i];
            item.ColorPlayerPhrases = phrases.colorPlayerPhrases[i];
            item.Name = lvl.PlayerName;
            ToTheCorrespondenceField.Enqueue(item);
        }
    }

    protected void PlayerConvector(Answer answer)
    {
        
        var item = new Player();
        item.Message = answer.Message;
        item.Name = answer.Name;
        ToTheCorrespondenceField.Enqueue(item);
    }
    

    protected void ClearSelectBox()
    {
        foreach (Transform it in selectBox.transform)
        {
            Destroy(it.gameObject);
        }
    }

    protected virtual void EndGame(bool win)
    {
   
    }
}