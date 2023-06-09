using System.Collections;
using UnityEngine;

public class ItemCompanion : ItemBase
{
    [SerializeField] private GameObject _writes;

    [SerializeField] private GameObject _messageObject;

    [SerializeField] private AvatarForm _avatar;

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

    public void SetMessage(string messege, float delay, string[] name)
    {
        StartCoroutine(StartAnimation(messege, delay));
        _avatar.SetAvatar(name);
    }
}