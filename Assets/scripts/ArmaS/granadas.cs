using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class granadas : MonoBehaviour
{
    [SerializeField] LayerMask quedetecto;
    [SerializeField] float radioExplosion;
    private Rigidbody rb;
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * 15 ,ForceMode.Impulse);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnDestroy()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, quedetecto);
        Instantiate(explosion, transform.position, Quaternion.identity);
       
        if (collsDetectados.Length > 0) 
        {
            foreach (Collider coll in collsDetectados) 
            {
                coll.GetComponent<enemyPart>().Explotar();
                coll.GetComponent<Rigidbody>().isKinematic = false;
                coll.GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, radioExplosion, 3.5f, ForceMode.Impulse);
            
            }

        
        }
        

    }

}
