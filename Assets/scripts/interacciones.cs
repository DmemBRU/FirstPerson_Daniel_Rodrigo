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
            if(hitInfo.transform.CompareTag("caja"))
            {
                Debug.Log("es una caja");
                interactuableActual = hitInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
            }
            else if (interactuableActual)
            {
                interactuableActual.GetComponent <Outline>().enabled = false;
                interactuableActual = null;
            }

            
        }
    }
}
