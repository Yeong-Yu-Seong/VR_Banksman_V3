using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnNPCLevel2 : MonoBehaviour
{
    public int junctionPartIndex;
    public bool isSpawn;
    private void OnTriggerEnter(Collider other)
    {

        // ===================================================

        if (other.transform.tag == "npcLevel2") 
        {
            if(other.GetComponent<NPCWalkLevel2>() != null)
            {
                if (isSpawn && (other.GetComponent<NPCWalkLevel2>().destinationNum == junctionPartIndex))
                {
                    gameEvents.current.lvl2IntoDespawn(other.GetComponent<NPCWalkLevel2>().NPCIndex, true);
                }
                else if (!isSpawn && (other.GetComponent<NPCWalkLevel2>().destinationNum == transform.GetComponentInParent<junction>().juctionIndex && other.GetComponent<NPCWalkLevel2>().junctionPartNum == junctionPartIndex))
                {
                    gameEvents.current.lvl2IntoDespawn(other.GetComponent<NPCWalkLevel2>().NPCIndex, false);
                }
            }
        }
    }
}