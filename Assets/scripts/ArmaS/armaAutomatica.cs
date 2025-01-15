using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaAutomatica : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam =  Camera.main;

        //misDatos.cadencia
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if (timer > 0)
        {
            if (Input.GetMouseButton(0) && timer >= misDatos.cadencia )
            {
                timer = 0;
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
}
