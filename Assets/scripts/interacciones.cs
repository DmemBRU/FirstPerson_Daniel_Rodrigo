using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interacciones : MonoBehaviour
{
    

    [SerializeField]private Camera cam;
    [SerializeField] float distanciaInteraccion;
    [SerializeField] Transform Player;
    Transform interactuableActual;
    [SerializeField] TMP_Text textoLlaves;
    int llaves = 0;
    weaponHolder� weaponHolder�;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        if ( Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo))
        {
            if(hitInfo.transform.TryGetComponent(out Objetos scriptObjeto))
            {
                interactuableActual = hitInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                 if (Input.GetKeyDown(KeyCode.E))
                {
                   
                   if(scriptObjeto.EsLlave == true)
                   {
                    scriptObjeto.ObtenerLlaves();
                    llaves++;
                    textoLlaves.SetText(":" + llaves);
                     
                   }
                   if(scriptObjeto.EsPistola == true)
                   {

                        weaponHolder�.recibirArma(1);
                    
                   }
                    if (scriptObjeto.EsEscopeta == true)
                    {

                        weaponHolder�.recibirArma(2);

                    }
                    if (scriptObjeto.EsAutomatica == true)
                    {

                        weaponHolder�.recibirArma(3);

                    }
                    if (scriptObjeto.EsLanzaGranadas == true)
                    {

                        weaponHolder�.recibirArma(4);

                    }
                }
            }
            else if(hitInfo.transform.TryGetComponent(out cohete scriptCohete))
            {
                 interactuableActual = hitInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                if(llaves <=3)
                {
                    scriptCohete.lanzarCohete();
                }
            }
            else if (interactuableActual)
            {
           
             interactuableActual.GetComponent<Outline>().enabled = false;
          
             interactuableActual = null;
            }
         
        }
    }
}
