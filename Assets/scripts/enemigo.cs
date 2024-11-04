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
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<firstPerson>();
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
}
