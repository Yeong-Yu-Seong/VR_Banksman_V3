using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcWalk : MonoBehaviour
{
    public int NPCNumber;
    int activatedNPC;
    public NavMeshAgent npc;
    public List<GameObject> targetLists = new List<GameObject>();
    public int targetNum;
    public int NPChurry;
    public float NPCNormalSpeed;
    public bool npcStart;
    public GameObject NNPCSight;

    private void Start()
    {
        gameEvents.current.onCurrentSequence += npcToWalk;
        if(!npcStart)
        {
            NNPCSight.GetComponent<npcSight>().currentSpeed = 0;
            GetComponent<NavMeshAgent>().speed = 0;
        }
    }
    void npcToWalk(int npcNum)
    {
        activatedNPC = npcNum;
    }
    // Update is called once per frame
    void Update()
    {
        if(npc.enabled == true && targetLists[targetNum] != null)
            npc.SetDestination(targetLists[targetNum].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "car" && other.transform.name == "killCollider")
        {
            npc.enabled = false;
        }
    }
}
