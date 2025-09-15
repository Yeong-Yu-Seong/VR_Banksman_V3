using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class npcStart : MonoBehaviour
{
    public GameObject NNPC;
    public GameObject NNPCSight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "car")
        {
            NNPCSight.GetComponent<npcSight>().currentSpeed = NNPC.GetComponent<npcWalk>().NPCNormalSpeed;
            NNPC.GetComponent<NavMeshAgent>().speed = NNPC.GetComponent<npcWalk>().NPCNormalSpeed;
        }
    }
}
