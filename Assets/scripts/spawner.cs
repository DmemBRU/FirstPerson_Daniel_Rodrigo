using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawns;
    [SerializeField] GameObject enemigoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generarUnEnemigo());
    }

    IEnumerator generarUnEnemigo()
    {
       
        while (true) 
        {
            Instantiate(enemigoPrefab, puntosSpawns[Random.Range(0,puntosSpawns.Length)].position, Quaternion.identity);
            yield return null;

        }
    }
}
