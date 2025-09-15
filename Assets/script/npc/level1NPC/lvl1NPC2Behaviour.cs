using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1NPC2Behaviour : MonoBehaviour
{
    public npcWalk NPCController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "NPCPoint")
        {
            NPCController.targetNum++;
        }
    }
}
