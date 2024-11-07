using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolita : MonoBehaviour
{
    [SerializeField]ParticleSystem system;
    [SerializeField] ArmaSO misDatos;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //est selecciona la camara de la escena que esta marcada como MAIN
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("PIUM");
           
            system.Play();

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.rango))
            {
                Debug.Log(hitInfo.transform.name);

                hitInfo.transform.GetComponent<enemigo>().RecibirDanio(misDatos.daño);


            }
        
        }
    }
}
