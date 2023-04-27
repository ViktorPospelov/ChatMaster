using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarForm : MonoBehaviour
{
    [SerializeField] private GameObject[] _avatar;

    public void SetAvatar(string[] name)
    {
        foreach (var av in _avatar)
        {
            av.SetActive(false);
        }
        foreach (var av in _avatar)
        {
            if (av.name.ToLower() == name[1].ToLower()) av.SetActive(true);
        }
    }
}
