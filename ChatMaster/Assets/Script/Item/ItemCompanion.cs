using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemCompanion : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private GameObject _writes;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private GameObject _messageObject;
    
    private const float _maxTimeWrite = 1.5f;
    private const float _minTimeWrite = 0.2f;
    

    private IEnumerator StartAnimation(string message)
    {
        float timeWrite = _minTimeWrite;
        timeWrite = Random.Range(_minTimeWrite,_maxTimeWrite) + (message.Length*_minTimeWrite/20f);
        Debug.Log(timeWrite);
        _messageObject.SetActive(false);
        _writes.SetActive(true);
        yield return new WaitForSeconds(timeWrite);
        _writes.SetActive(false);
        _messageObject.SetActive(true);
        _message.text = message;
        
        GameField.NormalizePosition(this.gameObject);
    }
    
    

    public void SetMessage(string masege)
    {
        StartCoroutine(StartAnimation(masege));
    }
}
