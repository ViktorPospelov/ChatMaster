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
    
   
    void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        _messageObject.SetActive(false);
        _messageObject.SetActive(true);
        _message.text = "Работает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вот";
        
        
        FindObjectOfType<GameField>().NormalizePosition(this.gameObject);
    }
    
}
