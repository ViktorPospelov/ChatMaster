using TMPro;
using UnityEngine;

public class LevelHeading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _formWinPopap;
    void Start()
    {
        _formWinPopap.text = "Привет, я чат игра";
    }
    
}
