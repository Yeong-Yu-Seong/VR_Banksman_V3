using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class forkHight : MonoBehaviour
{
    public TextMeshProUGUI forkTooHighLowDisplay;
    public GameObject forkTooHighLowDisplayObject;
    public List<Material> forkHeightCheckMaterials = new List<Material>();
    // Material 0 = green, Material 1 = red
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "forkLevel" && transform.name == "forkHeightCheck")
        {
            gameEvents.current.forkIsInPlace(true);
            forkTooHighLowDisplay.text = "";
            forkTooHighLowDisplayObject.SetActive(false);
            transform.GetComponent<MeshRenderer>().material = forkHeightCheckMaterials[0];
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
            transform.GetComponent<MeshRenderer>().material = forkHeightCheckMaterials[1];
        }
    }
}