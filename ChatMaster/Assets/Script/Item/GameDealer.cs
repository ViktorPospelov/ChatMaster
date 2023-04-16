using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDealer : GameField
{
    void Start()
    {
        
        var it = Instantiate(itemCompanion, correspondenceField);
        it.SetMessage("Привет игра, это я твой разрабочик");
    }
    
}