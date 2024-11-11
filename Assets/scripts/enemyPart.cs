using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPart : MonoBehaviour
{
    [SerializeField]private enemigo mainScript;
    [SerializeField] private float multiplicador;
    public void RecibirDanio(float danioRecibido)
    {
        mainScript.Vida -= danioRecibido * multiplicador;
        if (mainScript.Vida <= 0)
        {
            mainScript.morir();

        }

    }
}
