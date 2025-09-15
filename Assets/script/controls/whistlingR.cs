using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class whistlingR : MonoBehaviour
{
    public GameObject whistelDisplayR;
    public SteamVR_Action_Single BEEP;
    public SteamVR_Action_Single show;
    public GameObject whistleSound;

    // Update is called once per frame
    private void Start()
    {
        whistelDisplayR = GameObject.Find("whistleR");
    }
    void FixedUpdate()
    {
        if (show.axis > 0)
        {
            whistelDisplayR.SetActive(true);
            whistelDisplayR.transform.position = transform.position + new Vector3(0.05f, 0, 0);
            whistelDisplayR.transform.rotation = transform.rotation;
        }
        else
        {
            whistelDisplayR.SetActive(false);
        }
        if (BEEP.axis > 0)
        {
                Instantiate(whistleSound, transform.position, Quaternion.identity);
                gameEvents.current.RWhistleButtonPress(true);   
                BEEPP();
        }
        else
        {
                beepDuration = 0;
                gameEvents.current.RWhistleButtonPress(false);
        }
            

    }
    int beepDuration;
    void BEEPP()
    {
        beepDuration += 1;
        if (beepDuration > 50)
        {
                gameEvents.current.RWhistleButtonHold();
        }
            
    }
}
