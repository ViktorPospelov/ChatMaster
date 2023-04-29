using System;
using Script.Item.FieldObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePopop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _formWinPopap;
    [SerializeField] private Button _nextLvl;
    [SerializeField] private Button _addCoin;

    private void Start()
    {
       _nextLvl.onClick.AddListener(() =>
       {
           
       });
       
    }
    
}
