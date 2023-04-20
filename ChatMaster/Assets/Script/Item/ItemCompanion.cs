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


    private IEnumerator StartAnimation(string mess, float delay)
    {
        _messageObject.SetActive(false);
        _writes.SetActive(true);
        yield return new WaitForSeconds(delay);
        _writes.SetActive(false);
        _messageObject.SetActive(true);
       message.text = mess;
      GameField.moveNext?.Invoke();
    }

    public void SetMessage(string masege,float delay)
    {
        StartCoroutine(StartAnimation(masege,delay));
    }
}
