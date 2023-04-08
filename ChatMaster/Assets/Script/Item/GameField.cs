using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject itemPlayer;
    [SerializeField] private GameObject itemCompanion;
    [SerializeField] private Transform spotToSpawn;
    [SerializeField] private GameObject answer;
    [SerializeField] private Transform selectBox;

    private const float _maxTimeSpawn = 1.5f;
    private const float _minTimeSpawn = 0.2f;

    private Coroutine spawnCorutine;
    
    public static Action<int> AnswerClick;

    void Start()
    {
        ClearField();
        AnswerClick += ActionOrAnswer;
        spawnCorutine = StartCoroutine(SpawnMassage());
        var answ = Instantiate(answer, selectBox);
        answer.GetComponent<Answers>().SetAnswerAndGetButton(AnswerState.Green, "Работа ск");
        
}

    private IEnumerator SpawnMassage()
    {
        var ic = Instantiate(itemCompanion, spotToSpawn);
        ic.GetComponent<ItemCompanion>().SetMessage("нармас работаетиадонармас работает так и надонармас работает так и надо");
        
        yield return new WaitForSeconds(4.5f);

        var ip = Instantiate(itemPlayer, spotToSpawn);
        ip.GetComponent<Player>().SetMessage("Да ЗАЕБС");
        yield return new WaitForSeconds(4.5f);
        spawnCorutine = StartCoroutine(SpawnMassage());
        
    }

    private void ActionOrAnswer(int num)
    {
        Debug.Log("Клик сука "+num);
    }
    public static void NormalizePosition(GameObject gameObject)
    {
        gameObject.transform.localScale += new Vector3(0, 0.001f, 0);
    }

    private void ClearField()
    {
        foreach (Transform t in spotToSpawn.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in selectBox.transform)
        {
            Destroy(t.gameObject);
        }
    }
}