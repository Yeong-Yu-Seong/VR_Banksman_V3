using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class banksman2Ani : MonoBehaviour
{
    public GameObject banksman2;
    public Animator banksman2Animator;
    public NavMeshAgent banksman2Nav;
    Vector3 initialPosition = new Vector3();
    private void Start()
    {
        gameEvents.current.onStopOps += stopCar;
        gameEvents.current.onCurrentSequence += updateSequenceNum;
    }
    int destinationNum;
    bool stopTraffic;
    bool banksmanEnd;
    void stopCar()
    {
        if (destinationNum == 1)
            stopTraffic = true;
        Debug.Log(stopTraffic);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "banksman2")
        {
            banksman2.GetComponent<banksmanFollow>().thumbsUp = true;
            banksman2Animator.SetTrigger("stoppingRoad");
            banksman2Nav.speed = .2f;
        }
    }
    void updateSequenceNum(int num)
    {
        destinationNum = num;
    }
    private void Update()
    {

        if (stopTraffic)
            banksman2Animator.SetTrigger("truckReach");
        
        else
        {
            if (initialPosition == banksman2.transform.position)
                banksman2Animator.SetBool("walk", false);
            else
                banksman2Animator.SetBool("walk", true);
            
        }
        initialPosition = banksman2.transform.position;
    }
}