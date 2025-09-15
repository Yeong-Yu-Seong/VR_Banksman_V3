using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class forkHight : MonoBehaviour
{
    public TextMeshProUGUI forkTooHighLowDisplay;
    public GameObject forkTooHighLowDisplayObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "forkLevel" && transform.name == "forkHeightCheck")
        {
            gameEvents.current.forkIsInPlace(true);
            forkTooHighLowDisplay.text = "";
            forkTooHighLowDisplayObject.SetActive(false);
        }
        else if (other.transform.name == "forkLevel" && transform.name == "tooHigh")
        {
            forkTooHighLowDisplayObject.SetActive(true);
            forkTooHighLowDisplay.text = "Fork too high";
        }
        else if (other.transform.name == "forkLevel" && transform.name == "tooLow")
        {
            forkTooHighLowDisplayObject.SetActive(true);
            forkTooHighLowDisplay.text = "Fork too low";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "forkLevel" && transform.name == "forkHeightCheck")
        {
            gameEvents.current.forkIsInPlace(false);
        }
    }
}