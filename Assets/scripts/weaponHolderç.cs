using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolderç : MonoBehaviour
{
    [SerializeField]public bool TengoPistola = false;
    [SerializeField]public bool TengoEscopeta = false;
    [SerializeField]public bool TengoAutomatica = false;
    [SerializeField]public bool TengoGranadas = false;


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
        if(TengoPistola == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { cambioArma(0); }
        }
        if(TengoPistola == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)) { cambioArma(1); }
            }
        if(TengoPistola == true)
        {
            if(Input.GetKeyDown(KeyCode.Alpha3)) { cambioArma(2); }
            }
        if(TengoPistola == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4)) { cambioArma(3); }
            }
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

    public void recibirArma(int arma)
    {
        if (arma == 1)
        {
            TengoPistola = true;
        }
        if (arma == 2)
        {
            TengoEscopeta = true;
        }
        if (arma == 3)
        {
            TengoAutomatica = true;
        }
        if (arma == 4)
        {
            TengoGranadas = true;
        }
    }
}   

