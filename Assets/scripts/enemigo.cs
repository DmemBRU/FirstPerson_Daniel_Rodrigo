using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private firstPerson player;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDaniable;
    [SerializeField] private float vida;
     private Rigidbody[] huesos;

    public float Vida { get => vida; set => vida = value; }

    // Start is called before the first frame update
    void Start()
    {
        //Collider[] collsDetectados
       agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<firstPerson>();

        cambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            //Animation.SetBool("attacking", true);
        }

        //if (ventanaAbierta)
       // {
       //     DetectarJugador()
       // }
    }

    private void DetectarJugador()
    {
      // Collider[] collsDetectados = Physics.OverlapSphere( atackPoint.position, radioAtaque, queEsDaniable);
        //Physics.CheckSphere();
    }
    public void morir()
    {
        cambiarEstadoHuesos(false);
        agent.enabled = false;
        Destroy(gameObject, 10);
    }
    private void cambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;

        }
    }
}
