using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class whistling : MonoBehaviour
{
    public GameObject whistelDisplayL;
    public bool isLeft;
    public SteamVR_Action_Single BEEP;
    public SteamVR_Action_Single show;
    public GameObject whistleSound;

    // Update is called once per frame
    private void Start()
    {
        whistelDisplayL = GameObject.Find("whistleL");
    }
    void FixedUpdate()
    {
        if (show.axis > 0)
        {
            whistelDisplayL.SetActive(true);
            whistelDisplayL.transform.position = transform.position + new Vector3(0.05f, 0, 0);
            whistelDisplayL.transform.rotation = transform.rotation;

        }
        else
        {
            whistelDisplayL.SetActive(false);
        }
        
        if (BEEP.axis > 0)
        {
                Instantiate(whistleSound, transform.position, Quaternion.identity);
                gameEvents.current.LWhistleButtonPress(true);
                BEEPP();
        }
        else
        {
                beepDuration = 0;
                gameEvents.current.LWhistleButtonPress(false);
        }
            

    }
    int beepDuration;
    void BEEPP()
    {
        beepDuration += 1;
        if (beepDuration > 50)
        {
            gameEvents.current.LWhistleButtonHold();
        }

    }
}
