using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class worldParameters : MonoBehaviour
{
   
    public Vignette efecto2;
  
    firstPerson player;
    // Start is called before the first frame update
    void Start()
    {
        efecto2 = GetComponent<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
