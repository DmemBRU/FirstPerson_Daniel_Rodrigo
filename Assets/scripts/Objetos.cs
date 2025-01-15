using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objetos : MonoBehaviour
{

    [SerializeField] public bool EsPistola = false;
    [SerializeField] public bool EsAutomatica = false;
    [SerializeField] public bool EsEscopeta = false;
    [SerializeField] public bool EsLanzaGranadas = false;
    [SerializeField] public bool EsLlave = false;


     [SerializeField] Vector3 rotacion;
    [SerializeField] Vector3 posicion;
    [SerializeField] int velocidadROT;
    [SerializeField] int velocidad;
    float temporizador;

    

    weaponHolderç weaponHolderç;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotacion * velocidadROT * Time.deltaTime);
        transform.Translate(posicion* velocidad * Time.deltaTime,Space.World);
        temporizador += 1 * Time.deltaTime;
        if (temporizador >= 1) 
        {
            velocidad *= -1;
            temporizador = 0;
        }
                   
    }
    public void ObtenerArmas()
    {
        if(EsPistola == true)
        {
            weaponHolderç.TengoPistola = true;
            Destroy(this.gameObject);
        }
        if(EsEscopeta == true)
        {
            weaponHolderç.TengoEscopeta = true;
            Destroy(this.gameObject);
        }
        if(EsAutomatica == true)
        {
            weaponHolderç.TengoAutomatica = true;
            Destroy(this.gameObject);
        }
        if(EsLanzaGranadas == true)
        {
            weaponHolderç.TengoGranadas = true;
            Destroy(this.gameObject);
        }
    }
    public void ObtenerLlaves()
    {
        Destroy(this.gameObject);
    }
}
