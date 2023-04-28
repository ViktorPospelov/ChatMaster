using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemPlayer : ItemBase
{
    [SerializeField] private AvatarForm avatar;
    [SerializeField] private GameObject messageObject;

    public void SetPlayerMessage(string message, string[] name)
    {
        base.SetMessage(message);
        avatar.SetAvatar(name);
    }

   
}
