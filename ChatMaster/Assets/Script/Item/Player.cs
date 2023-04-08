using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private GameObject _messageObject;
    
    

    public void SetMessage(string massage)
    {
        _messageObject.SetActive(false);
        _messageObject.SetActive(true);
        _message.text = massage;
        gameObject.transform.localScale += new Vector3(0, 0.001f, 0);
        GameField.NormalizePosition(this.gameObject);
    }
    
}
