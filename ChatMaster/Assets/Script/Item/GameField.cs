using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject itemPlayer;
    [SerializeField] private GameObject itemCompanion;
    [SerializeField] private Transform spotToSpawn;
    [SerializeField] private ScrollRect _scrollView;

    private Coroutine spawnCorutine;
    void Start()
    {
        spawnCorutine = StartCoroutine(SpawnMassage());
    }

    private IEnumerator SpawnMassage()
    {
        Instantiate(itemCompanion, spotToSpawn);
        yield return new WaitForSeconds(3.5f);
        Instantiate(itemPlayer, spotToSpawn);
        yield return new WaitForSeconds(3.5f);
        spawnCorutine = StartCoroutine(SpawnMassage());
       
    }

    public void NormalizePosition(GameObject gameObject)
    {
        gameObject.transform.localScale += new Vector3(0,0.001f,0);
    }
}
