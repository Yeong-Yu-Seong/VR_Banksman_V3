using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast1 : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    float raycastLength = 20;
    public bool targetLeftand;
    public GameObject handL;
    public GameObject handsR;
    void FixedUpdate()
    {


        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "hand")
            {
                if (targetLeftand)
                {
                    gameEvents.current.palmFrontL(0);
                }
                else
                {
                    gameEvents.current.palmFrontR(0);
                }
            }
            else if (targetLeftand)
            {
                if (hit.transform.name == "up")
                    gameEvents.current.palmFrontL(1);
                else if (hit.transform.name == "down")
                    gameEvents.current.palmFrontL(2);
                else
                    gameEvents.current.palmFrontL(0);
            }
            else
            {
                if (hit.transform.name == "up")
                    gameEvents.current.palmFrontR(1);
                else if (hit.transform.name == "down")
                    gameEvents.current.palmFrontR(2);
                else
                    gameEvents.current.palmFrontR(0);
            }
        }
        Debug.DrawLine(transform.position, transform.position + (transform.forward * raycastLength));
    }
    void followHands()
    {
        
    }
}
