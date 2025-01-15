using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{
  [SerializeField]ParticleSystem system;
    [SerializeField] ArmaSO misDatos;
    [SerializeField] AudioClip disparo;

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
                if (hitInfo.transform.CompareTag("enemyPart"))
                {
                    Debug.Log(hitInfo.transform.name);

                    hitInfo.transform.GetComponent<enemyPart>().RecibirDanio(misDatos.danho);
                }


            }
        
        }
    }
}
