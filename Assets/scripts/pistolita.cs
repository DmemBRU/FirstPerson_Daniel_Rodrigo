using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolita : MonoBehaviour
{
    [SerializeField]ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("PIUM");
            system.Play();
        
        }
    }
}
