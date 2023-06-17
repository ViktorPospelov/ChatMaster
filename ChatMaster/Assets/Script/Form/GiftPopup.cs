using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GiftPopup : MonoBehaviour
{
    [SerializeField] private Button _close;


    public void Start()
    {

        _close.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _close.onClick.RemoveAllListeners();
        });
    }
    
}