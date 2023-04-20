using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemPlayer : ItemBase
{
    [SerializeField] private Image avatar;
    [SerializeField] private GameObject messageObject;

    public override void SetMessage(string message)
    {
        base.SetMessage(message);
    }

   
}
