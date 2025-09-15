using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level2Sequence : MonoBehaviour
{
    public int triggerNum;
    public int targetNum;
    public GameObject car;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "car")
        {   
            
            if(triggerNum == 444 || triggerNum == 445)
            {
                gameEvents.current.levelReset();
            }
            else
            {
                gameEvents.current.currentSequence(triggerNum);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "car")
        {
            if (triggerNum == 444 || triggerNum == 445)
            {
                gameEvents.current.levelReset();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
