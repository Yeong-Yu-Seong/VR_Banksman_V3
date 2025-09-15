using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStopArea : MonoBehaviour
{
    public bool isTrafficStop;
    public List<int> destinationInt = new List<int>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "npcLevel2")
        {
            for(int i = 0; i < destinationInt.Count; i++)
                if(other.GetComponent<NPCWalkLevel2>().destinationNum == destinationInt[i])
                other.GetComponent<NPCWalkLevel2>().isStopTraffic = isTrafficStop; 
        }
    }
}
