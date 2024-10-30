using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private firstPerson player;
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
    }
}
