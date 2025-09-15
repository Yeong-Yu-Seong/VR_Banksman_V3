using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTraffic : MonoBehaviour
{

    public List<GameObject> stopTrafficColliderPlayer = new List<GameObject>();
    public List<GameObject> stopTrafficColliderNPCBanksman = new List<GameObject>();

    private void Start()
    {
        gameEvents.current.onStopOps += isNowStooped;
    }
    bool playerTriggerStop;
    void isNowStooped()
    {
        playerTriggerStop = true;
        StartCoroutine(stopOn1Frame());
    }

    IEnumerator stopOn1Frame()
    {
        yield return new WaitForFixedUpdate();
        playerTriggerStop = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player" && playerTriggerStop)
        {
            for (int i = 0; i < stopTrafficColliderPlayer.Count; i++)
            {
                stopTrafficColliderPlayer[i].GetComponent<NPCStopArea>().isTrafficStop = true;
            }
        }
        if (other.transform.name == "banksman2" && transform.name == "trafficController_Banksman2")
        {
            for (int i = 0; i < stopTrafficColliderNPCBanksman.Count; i++)
            {
                stopTrafficColliderNPCBanksman[i].GetComponent<NPCStopArea>().isTrafficStop = true;
            }
        }
    }

}
