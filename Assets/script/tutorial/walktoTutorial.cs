using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walktoTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameEvents.current.walktoTutorial();
            gameObject.SetActive(false);

            GameObject.Find("backOfClassTMPro").SetActive(false);
        }
    }
}
