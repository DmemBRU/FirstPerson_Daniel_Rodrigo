using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolderç : MonoBehaviour
{
    [SerializeField] GameObject[] armas;
    int armaActual = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armas[armaActual].SetActive(false);
            armas[0].SetActive(true);
            armaActual = 0;
        
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
             armas[armaActual].SetActive(false);
            armas[0].SetActive(true) ;
            armaActual = 1;

        }
            

    }
}
