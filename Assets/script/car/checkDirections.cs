using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDirections : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.name == "directionCheck")
            gameEvents.current.isStraight();
    }
}
