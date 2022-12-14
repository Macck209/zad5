using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    private Vector3[] targets;

    NavMeshAgent agent;

    void Start()
    {
        targets = new Vector3[]
        {
            GameObject.Find("Cel1").GetComponent<Transform>().position,
            GameObject.Find("Cel2").GetComponent<Transform>().position,
            GameObject.Find("Cel3").GetComponent<Transform>().position,
            GameObject.Find("Cel4").GetComponent<Transform>().position,
            GameObject.Find("Cel5").GetComponent<Transform>().position
        };

        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(randDestination(Vector3.zero));
    }
    private void Update()
    {
        if (agent.remainingDistance < 0.5)
        {
            agent.SetDestination(randDestination(agent.destination));
        }
    }

    private Vector3 randDestination(Vector3 lastDest)
    {
        int temp = Random.Range(0, 5);
        return (targets[temp]!= lastDest ? targets[temp] : randDestination(lastDest));
    }
}
