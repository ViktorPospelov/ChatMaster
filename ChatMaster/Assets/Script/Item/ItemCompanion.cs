using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class ItemCompanion : ItemBase
{
    [SerializeField] private Image _avatar;
    [SerializeField] private GameObject _writes;
    
    [SerializeField] private GameObject _messageObject;
   
    private const float _maxTimeWrite = 1.2f;
    private const float _minTimeWrite = 0.6f;

    // private void Start()
    // {
    //     SetMessage("Привет игра, это я твой разрабочик");
    // }

    private IEnumerator StartAnimation(string mess)
    {
        float timeWrite = _minTimeWrite;
        timeWrite = Random.Range(_minTimeWrite,_maxTimeWrite) + (mess.Length*_minTimeWrite/15f);
        Debug.Log(timeWrite);
        _messageObject.SetActive(false);
        _writes.SetActive(true);
        yield return new WaitForSeconds(timeWrite);
        _writes.SetActive(false);
        _messageObject.SetActive(true);
       message.text = mess;
        
       // GameField.NormalizePosition(this.gameObject);
     
        
    }

    public void SetMessage(string masege)
    {
        StartCoroutine(StartAnimation(masege));
    }
}
