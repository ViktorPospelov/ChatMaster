using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject itemCompanion;
    [SerializeField] private Transform spotToSpawn;

    private Coroutine spawnCorutine;
    void Start()
    {
        spawnCorutine = StartCoroutine(SpawnMassage());
    }

    private IEnumerator SpawnMassage()
    {
        Instantiate(itemCompanion, spotToSpawn);
        yield return new WaitForSeconds(6.5f);
        spawnCorutine = StartCoroutine(SpawnMassage());
    }

   }
