using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI message;

    public ItemState itemState;
}
