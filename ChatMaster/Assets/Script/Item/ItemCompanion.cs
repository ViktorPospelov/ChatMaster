using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemCompanion : ItemBase
{
    [SerializeField] private Image _avatar;
    [SerializeField] private GameObject _writes;
    
    [SerializeField] private GameObject _messageObject;
   
    private const float _maxTimeWrite = 1.2f;
    private const float _minTimeWrite = 0.6f;
    

    private IEnumerator StartAnimation(string message)
    {
        float timeWrite = _minTimeWrite;
        timeWrite = Random.Range(_minTimeWrite,_maxTimeWrite) + (message.Length*_minTimeWrite/15f);
        Debug.Log(timeWrite);
        _messageObject.SetActive(false);
        _writes.SetActive(true);
        yield return new WaitForSeconds(timeWrite);
        _writes.SetActive(false);
        _messageObject.SetActive(true);
        _message.text = message;
        
        GameField.NormalizePosition(this.gameObject);
        StartCoroutine(MoveNext());
        
    }
    
    private IEnumerator MoveNext()
    {
        yield return new WaitForSeconds(Random.Range(_minTimeWrite,_maxTimeWrite));
        GameField.ConpanionEndWrite?.Invoke();
    }
    
    
    
    public void SetMessage(string masege)
    {
        StartCoroutine(StartAnimation(masege));
    }
}
