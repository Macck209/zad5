using System.Collections;
using UnityEngine;

public class agentGenerator : MonoBehaviour
{

    public GameObject AgentPrefab;
    private Vector3 startPos;

    int agentCounter;

    void Start()
    {
        agentCounter= 0;
        startPos = GameObject.Find("StartAgent").transform.position + new Vector3(0, 1, 0);
        StartCoroutine(SpawnAgent());
    }
    private IEnumerator SpawnAgent()
    {
        GameObject.Instantiate(AgentPrefab, startPos, Quaternion.identity);
        agentCounter++;
        if (agentCounter < 10)
        {
            yield return new WaitForSeconds(4);
            StartCoroutine(SpawnAgent());
        }
    }
}
