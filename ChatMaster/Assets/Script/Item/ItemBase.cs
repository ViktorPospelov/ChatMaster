using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI message;

    
    
    public virtual void SetMessage(string message)
    {
        this.message.text = message;
        GameField.moveNext?.Invoke();
    }
}
