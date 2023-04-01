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
    
   
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        _messageObject.SetActive(false);
        _writes.SetActive(true);
        yield return new WaitForSeconds(1f);
        _writes.SetActive(false);
        _messageObject.SetActive(true);
        _message.text = "Работает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вотРаботает, вот так вот";
        
    }
    
}
