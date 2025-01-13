using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolderç : MonoBehaviour
{
    [SerializeField] GameObject[] armas;
    int armaActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cambioArmaNumeros();
        cambioArmaRaton();

    }

    private void cambioArmaNumeros()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { cambioArma(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { cambioArma(1); }
        if(Input.GetKeyDown(KeyCode.Alpha3)) { cambioArma(2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { cambioArma(3); }
    }
    private void cambioArmaRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0) //Anterior
        {
            cambioArma(armaActual - 1);
        }
        else if (scrollWheel < 0) //Siguiente
        {
            cambioArma(armaActual + 1);
        }
    }
    private void cambioArma(int nuevoIndice)
    {

        if (nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {
            armas[armaActual].SetActive(false) ;
            armaActual = nuevoIndice;
            armas[armaActual].SetActive(true);
        }
    }
}

