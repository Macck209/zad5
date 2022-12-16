using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class agentGenerator : MonoBehaviour
{

    public GameObject AgentPrefab;
    private Vector3 startPos;
    public Text agentNum;
    public AudioClip ding;

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
        agentNum.text = agentCounter.ToString();
        AudioSource.PlayClipAtPoint(ding, transform.position);
        if (agentCounter < 10)
        {
            yield return new WaitForSeconds(10);
            StartCoroutine(SpawnAgent());
        }
    }
}
