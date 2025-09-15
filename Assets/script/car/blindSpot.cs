using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blindSpot : MonoBehaviour
{
    public bool isback;
    public bool isFront;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")  
        {
            if(name == "notBlindSpot")
                gameEvents.current.canSeePlayer(true, isback, isFront);
                
            if(name == "warning")
                gameEvents.current.tooCloseToCar(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (name == "notBlindSpot")
                gameEvents.current.canSeePlayer(false, false, false );
            if (name == "warning")
                gameEvents.current.tooCloseToCar(false);
        }
    }
}