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
    [SerializeField] private LvL[] lvls;
    private GameManager gameManager;

    private const float _maxTimeSpawn = 1.5f;
    private const float _minTimeSpawn = 0.2f;

    private Coroutine spawnCorutine;


    void Start()
    {
        ClearField();
        gameManager = new GameManager(lvls[0], this);
        
        gameManager.StartLVL();
    }
    
    public void SpawnAnswerButton(string massage, AnswerState answerState, int prise, int answerNextIndex)
    {
        var answ = Instantiate(answer, selectBox);
        answ.GetComponent<AnswersP>().SetAnswer(prise, answerState, massage, answerNextIndex);
    }
    public void SpawnCompanionMassage(string massage)
    {
        var ic = Instantiate(itemCompanion, spotToSpawn);
        ic.GetComponent<ItemCompanion>()
            .SetMessage(massage);
    }
    public void SpawnPlayerMassage(string massage)
    {
        var ip = Instantiate(itemPlayer, spotToSpawn);
        ip.GetComponent<Player>().SetMessage(massage);
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

        ClearAnswerBox();
    }

    public void ClearAnswerBox()
    {
        foreach (Transform t in selectBox.transform)
        {
            Destroy(t.gameObject);
        }
    }
}