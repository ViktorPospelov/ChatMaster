using UnityEngine;

[CreateAssetMenu(fileName = "LvL", menuName = "Scripble Objects/LvL")]
public class LvL : ScriptableObject
{
    public int lvlNumber;
    public string taskAtTheLevel;
    public Phrases[] CompanionPhrases;
}
