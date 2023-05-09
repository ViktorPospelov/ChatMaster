using UnityEngine;
using UnityEngine.UI;

public class MarketForm : MonoBehaviour
{
    [SerializeField] private Button _close;
    void Awake()
    {
        _close.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
