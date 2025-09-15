using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalkLevel2 : MonoBehaviour
{
    public float NPCIndex;
    public int NPChurry;
    public int NPCNormalSpeed;
    public GameObject NNPCSight;
    public int spawnLocation;
    public int destinationNum;
    public int junctionPartNum;
    public NavMeshAgent npcAgent;
    public bool toDespawn;
    public bool isStopTraffic;

    void Start()
    {
        gameObject.transform.name = "npcLevel2";
        gameEvents.current.onLvl2IntoDespawn += turnNPC;
        NPCIndex = Time.deltaTime;
        spawnLocation = Random.Range(0, 4);
        destinationNum = Random.Range(0, 4);
        junctionPartNum = Random.Range(0, 4);       
        while (destinationNum == spawnLocation)
        {
            destinationNum = Random.Range(0, 4);
        }
        for( int i = 0; i < GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().npcSpawnArea.Count; i++)
            {
                if (i == spawnLocation)
                {
                    transform.position = GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().npcSpawnArea[i].transform.position;
                }
            }
    }

    void turnNPC(float npcIndex , bool delete)
    {
        if (npcIndex == NPCIndex && !delete)
        {
            toDespawn = true;
            StartCoroutine(despawnTimer());
        }
        else if (npcIndex == NPCIndex && delete)
        {
            GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().NPCAmmount--;
            Destroy(gameObject);
        }
    }
    IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        NNPCSight.SetActive(GetComponent<NavMeshAgent>().enabled);

        npcAgent.enabled = !isStopTraffic;
        if (!toDespawn)
            npcAgent.SetDestination(GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().junctions[destinationNum].GetComponent<junction>().JunctionsParts[junctionPartNum].transform.position);
        else
            npcAgent.SetDestination(GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().npcSpawnArea[destinationNum].transform.position);
    }
}
