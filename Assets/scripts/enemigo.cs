using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private firstPerson player;

    private Animator anim;
    private bool ventanaAbierta = false;

    [SerializeField] private float danioAtaque;
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDaniable;
    private bool danioRealizado = false;
    [SerializeField] private float vida;
    private Rigidbody[] huesos;

    public float Vida { get => vida; set => vida = value; }

    // Start is called before the first frame update
    void Start()
    {
        //Collider[] collsDetectados
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<firstPerson>();
        anim = GetComponent<Animator>();
        //huesos = GetComponentInChildren<Rigidbody>();


        cambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        perseguir();
       

        if (ventanaAbierta && danioRealizado == false)
        {
            DetectarJugador();
        }
    }

    private void DetectarJugador()
    {
      Collider[] collsDetectados = Physics.OverlapSphere( puntoAtaque.position, radioAtaque, queEsDaniable);
        if(collsDetectados.Length > 0)
        {
            for(int i=0; i<collsDetectados.Length; i++){

                collsDetectados[i].GetComponent<firstPerson>().recibirdanio(danioAtaque);
            }
            danioRealizado = true;
        }
    }

    private void perseguir()
    {
        agent.SetDestination(player.transform.position);
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("ataque", true);
            enfocarPlayer();
        }
    }

    public void morir()
    {
        cambiarEstadoHuesos(false);
        agent.enabled = false;
        anim.enabled = false;
        Destroy(gameObject, 10);
    }
    private void cambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;

        }
    }

    private void enfocarPlayer()
    {
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;
        direccionAPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);

    }

}
