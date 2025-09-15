using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;


public class npcSight : MonoBehaviour
{
    bool seesCar = false;
    public float currentSpeed;
    public float slowDownAmmount;
    public bool stopRoad;
    public GameObject controller;
    public Animator NPCAnimation;
    public bool NPCisDead;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && transform.GetComponentInParent<NavMeshAgent>().enabled == true)
        {
            StartCoroutine(walkAnyState());
            controller.GetComponent<walkNPCController>().isWalking = true;
            currentSpeed = transform.GetComponentInParent<NPCWalkLevel2>().NPCNormalSpeed;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            controller.GetComponent<walkNPCController>().isWalking = true;
            currentSpeed = 0;
        }
    }

    IEnumerator walkAnyState()
    {
        if (!NPCisDead)
        {
            NPCAnimation.SetInteger("walk", Random.Range(1, 5));
            NPCAnimation.SetInteger("idel", 0);
            yield return new WaitForSeconds(0.5f);
            NPCAnimation.SetInteger("walk", 0);
        }
    }
    private void Update()
    {
        if(!NPCisDead)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
                transform.GetComponentInParent<NavMeshAgent>().speed = currentSpeed;
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (!transform.GetComponentInParent<NPCWalkLevel2>().isStopTraffic && transform.GetComponentInParent<NavMeshAgent>().enabled == true)
                {
                    if (seesCar)
                    {
                        transform.GetComponentInParent<NavMeshAgent>().speed = 0;
                    }
                    else
                    {
                        transform.GetComponentInParent<NavMeshAgent>().speed = currentSpeed;
                    }
                }
                else if (transform.GetComponentInParent<NavMeshAgent>().enabled == false)
                {
                    NPCAnimation.SetInteger("idel", Random.Range(1, 3));
                }
            }
        }
        
    }
    public bool seeNPC;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "car" && !NPCisDead && transform.GetComponentInParent<NavMeshAgent>().enabled == true && (SceneManager.GetActiveScene().buildIndex == 1 ||  !seeNPC))
        {
            StartCoroutine(noticeTime());
        }
        else if (other.transform.tag == "NPC" && seeNPC && (SceneManager.GetActiveScene().buildIndex == 1 || seeNPC))
        {
            if (stopRoad)
            {
                StartCoroutine(noticeTime());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "car")
        {

            seesCar = false;
            StartCoroutine(SpeedUpDurationCar());
        }
        else if(other.transform.tag == "NPC")
        {
            StartCoroutine(SpeedUpDurationNPC());
        }
    }
    IEnumerator SpeedUpDurationCar()
    {
        NPCAnimation.SetTrigger("run");
        NPCAnimation.SetInteger("idel", 0);
        if (SceneManager.GetActiveScene().buildIndex == 1)
            currentSpeed = transform.GetComponentInParent<npcWalk>().NPChurry;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            currentSpeed = transform.GetComponentInParent<NPCWalkLevel2>().NPChurry;
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        if (SceneManager.GetActiveScene().buildIndex == 1)
            currentSpeed = transform.GetComponentInParent<npcWalk>().NPCNormalSpeed;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            currentSpeed = transform.GetComponentInParent<NPCWalkLevel2>().NPCNormalSpeed;
        StartCoroutine(walkAnyState());
    }
    IEnumerator SpeedUpDurationNPC()
    {
        NPCAnimation.SetTrigger("run");
        NPCAnimation.SetInteger("idel", 0);
        if (SceneManager.GetActiveScene().buildIndex == 1)
            currentSpeed = transform.GetComponentInParent<npcWalk>().NPChurry;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            currentSpeed = transform.GetComponentInParent<NPCWalkLevel2>().NPChurry;
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (SceneManager.GetActiveScene().buildIndex == 1)
            currentSpeed = transform.GetComponentInParent<npcWalk>().NPCNormalSpeed;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            currentSpeed = transform.GetComponentInParent<NPCWalkLevel2>().NPCNormalSpeed;
        StartCoroutine(walkAnyState());
    }
    IEnumerator noticeTime()
    {
        yield return new WaitForSeconds(Random.Range(0f, .01f));
        currentSpeed = 0;
        seesCar = true;
        NPCAnimation.SetInteger("idel", Random.Range(1, 3));
    }
}