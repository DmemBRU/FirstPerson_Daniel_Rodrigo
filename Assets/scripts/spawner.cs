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
        
    }

    IEnumerator generarUnEnemigo()
    {
        Instantiate(enemigoPrefab, puntosSpawns[0].position, Quaternion.identity);
        yield return null;  

    }
}
