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
    [SerializeField] private GameObject itemPlayer;
    [SerializeField] private GameObject itemCompanion;
    [SerializeField] private Transform spotToSpawn;
    [SerializeField] private GameObject answer;
    [SerializeField] private Transform selectBox;
    [SerializeField] private LvL[] lvls;
    public static GameManager gameManager;

  

    void Start()
    {
       
    }

   
}