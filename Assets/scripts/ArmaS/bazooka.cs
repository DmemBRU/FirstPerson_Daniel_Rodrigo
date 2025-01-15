using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazooka : MonoBehaviour
{

    [SerializeField] GameObject granada;
    [SerializeField] Transform spawnPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(granada, spawnPoint.position, spawnPoint.rotation);
           
        
        }
    }
}
