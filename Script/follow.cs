using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (target.gameObject.tag.Equals("Player"))
        { 
            navAgent.SetDestination(target.position);
        }
    }

}
