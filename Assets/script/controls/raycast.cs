using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    float raycastLength = 20;
    public bool targetLeftand;
    public GameObject handL;
    public GameObject handsR;
    void FixedUpdate()
    {
        followHands();

        if (targetLeftand)
        {
            gameEvents.current.palmDownL(0);
        }
        else
        {
            gameEvents.current.palmDownR(0);
        }
        if (Physics.Raycast(transform.position,transform.forward, out hit, raycastLength))
        {
            /*if (Physics.Raycast(ray, raycastLength, 8))
            {*/
                if (hit.transform.tag == "hand")
                    return;
                else if (targetLeftand)
                {
                    if (hit.transform.name == "up")
                        gameEvents.current.palmDownL(1);
                    else if (hit.transform.name == "down")
                        gameEvents.current.palmDownL(2);
                }
                else
                {
                    if (hit.transform.name == "up")
                        gameEvents.current.palmDownR(1);
                    else if (hit.transform.name == "down")
                        gameEvents.current.palmDownR(2);
                }
           /* }*/
        }
        else
        {

        }
        /*gameEvents.current.palmDown(false);*/

        Debug.DrawLine(transform.position, transform.position + (transform.forward * raycastLength));
    }
    void followHands()
    {
        if(targetLeftand)
        {
            transform.position = new Vector3(handL.transform.position.x, 0 -20, handL.transform.position.z);

        }
        else
        {
            transform.position = new Vector3(handsR.transform.position.x, 0-20, handsR.transform.position.z);
        }
    }
}
