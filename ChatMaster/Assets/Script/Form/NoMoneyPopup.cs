using UnityEngine;
using UnityEngine.UI;
public class NoMoneyPopup : MonoBehaviour
{
    
    [SerializeField] private Button _market;
    [SerializeField] private Button _close;
    [SerializeField] private Button _close2;
    [SerializeField] private MarketForm _marketForm;
    public void OnEnable()
    {
        _market.onClick.RemoveAllListeners();
        _close2.onClick.RemoveAllListeners();
        _close.onClick.RemoveAllListeners();
        
        _market.onClick.AddListener(() =>
        {
            _marketForm.gameObject.SetActive(true);
            gameObject.SetActive(false);
        });
        _close.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        }); 
        _close2.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
    
}