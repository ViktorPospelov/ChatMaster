
using UnityEngine;

[CreateAssetMenu(fileName = "LvL", menuName = "Scripble Objects/Phrases")]
public class Phrases : ScriptableObject
{
    public string[] companionPhrases;
    public string[] playerPhrases;
    [Header("999 - win, 998 - lose")]
    public int[] phraseJumpIndex;
    public int[] prisePlayerPhrases;
    public int[] colorPlayerPhrases;
    
}
