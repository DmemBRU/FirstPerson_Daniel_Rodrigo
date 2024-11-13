using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacciones : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField] int distanciaMin;
    Transform interactuableActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo))
        {
            

            if(hitInfo.transform.TryGetComponent(out caja scriptcaja))
            {
                interactuableActual = hitInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptcaja.abrir();

                }

            }
        }
    }
}
