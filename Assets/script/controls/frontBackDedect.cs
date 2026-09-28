using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontBackDedect : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    float raycastLength = 20;
    public GameObject directionCube;
    private void Start()
    {
        gameEvents.current.onAwayMe += triggerAwayMe;
        gameEvents.current.onToMe += triggerToMe;
        gameEvents.current.onCanSeePlayer += playerInView;
    }

    bool canSee;
    bool isbackNotBlindSpot;
    bool isfrontNotBlindSpot;
    void playerInView(bool isCanSee, bool isInBackNotBlindSpot, bool isInFrontNotBlindSpot)
    {
        canSee = isCanSee;
        isbackNotBlindSpot = isInBackNotBlindSpot;
        isfrontNotBlindSpot = isInFrontNotBlindSpot;
    }

    /*fliiped : to me*/
    void triggerAwayMe()
    {
        /*moving back*/
        if (isFacing == 1)
        {
            if (isbackNotBlindSpot || (isbackNotBlindSpot && isfrontNotBlindSpot))
                gameEvents.current.carForward();
            else if (isfrontNotBlindSpot)
                gameEvents.current.giveInstruction("Driver cannot see your hands");
        }
        /*moving front*/
        else if (isFacing == 2)
        {
            if (isfrontNotBlindSpot || (isbackNotBlindSpot && isfrontNotBlindSpot))
                gameEvents.current.carBackward();
            else if (isbackNotBlindSpot || !(isbackNotBlindSpot && isfrontNotBlindSpot))
                gameEvents.current.giveInstruction("Driver cannot see your hands");
        }
        else
            gameEvents.current.giveInstruction("Vehicle cannot move that direction");
    }
    /*fliiped : away me*/
    void triggerToMe()
    {
        /*moving front*/
        if (isFacing == 2)
        {
            if (isbackNotBlindSpot && !isfrontNotBlindSpot)
                gameEvents.current.giveInstruction("Go to front of vehicle");
            else if (isfrontNotBlindSpot && !isbackNotBlindSpot)
                gameEvents.current.giveInstruction("Driver cannot see your hands");
            else if(isbackNotBlindSpot && isfrontNotBlindSpot)
                gameEvents.current.carForward();
        }
        /*moving back*/
        else if (isFacing == 1)
        {
            if (isbackNotBlindSpot && !isfrontNotBlindSpot)
                gameEvents.current.giveInstruction("Driver cannot see your hands");
            else if (isfrontNotBlindSpot && !isbackNotBlindSpot)
                gameEvents.current.giveInstruction("Go to back of vehicle");
            else if (isbackNotBlindSpot && isfrontNotBlindSpot)
                gameEvents.current.carBackward();
        }
            
        else
            gameEvents.current.giveInstruction("vehicle cannot move that direction");
    }
    int isFacing;
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.name == "face")
            {
                isFacing = 1;
            } 
            else if (hit.transform.name == "notFace")
            {
                isFacing = 2;
            }
            else
            {
                isFacing = 0;
            }
        }
        else
        {
            isFacing = 0;
        }
    }
}