using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class walkNPCController : MonoBehaviour
{
    public Animator NPCWalkAni;
    bool canFidget = true;
    public int crashDirection;
    
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        NPCWalkAni.SetInteger("idel", Random.Range(1, 3));
    }

    Vector3 lastPosition = Vector3.zero;
    public bool isWalking;
    public bool isIdelNPC;
    bool canWalk = true;
    bool canRun = true;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !isIdelNPC)
        {
            if(transform.GetComponentInParent<NavMeshAgent>().speed == 0 && !canWalk)
            {
                isWalking = false;
                canRun = true;
                NPCWalkAni.SetInteger("idel", Random.Range(1, 3));
                StartCoroutine(stopWalk());
            }
            else if (transform.GetComponentInParent<NavMeshAgent>().speed > 0 && transform.GetComponentInParent<NavMeshAgent>().speed < 4 && canWalk)
            {
                isWalking = true;
                canRun = true;
                StartCoroutine(walk());
            }
            else if (transform.GetComponentInParent<NavMeshAgent>().speed > 0 && transform.GetComponentInParent<NavMeshAgent>().speed >= 4 && canRun)
            {
                canRun = false;
                npcIsRunning();
            }
        }
        if (!isWalking)
        {
            if (canFidget)
            {
                canFidget = !canFidget;
                StartCoroutine(fidgetCD());
            }
        }
    }
    private void FixedUpdate()
    {
        if (crashDirection == 1)
            StartCoroutine(crashed(2));
        else if (crashDirection == 2)
            StartCoroutine(crashed(1));
    }
    IEnumerator walk()
    {
        canWalk = false;
        NPCWalkAni.SetInteger("idel", 0);
        NPCWalkAni.SetInteger("walk", Random.Range(1, 4));
        yield return new WaitForEndOfFrameUnit();
        NPCWalkAni.SetInteger("walk", 0);
    }
    IEnumerator stopWalk()
    {
        canWalk = true;
        NPCWalkAni.SetInteger("idel", Random.Range(1, 3));
        NPCWalkAni.SetInteger("walk", 0);
        yield return new WaitForEndOfFrameUnit();
        NPCWalkAni.SetInteger("idel", 0);
    }
    IEnumerator crashed(int side)
    {
        NPCWalkAni.SetInteger("crash", side);
        yield return new WaitForEndOfFrameUnit();
        NPCWalkAni.SetInteger("crash", 0);
        GetComponent<walkNPCController>().enabled = false;
    }
    
    IEnumerator fidgetCD()
    {
        yield return new WaitForSeconds(Random.Range(8f, 80f));
        NPCWalkAni.SetInteger("idel", 0);
        NPCWalkAni.SetInteger("fidget", Random.Range(0,4));
        yield return new WaitForSeconds(Random.Range(2.5f, 5f));
        NPCWalkAni.SetInteger("fidget", 0);
        NPCWalkAni.SetInteger("idel", Random.Range(1,3));
        canFidget = !canFidget;
    }

    void npcIsWalking()
    {
        NPCWalkAni.SetInteger("idel", 0);
        StartCoroutine(npcWalkAni());
    }

    IEnumerator npcWalkAni()
    {
        NPCWalkAni.SetInteger("walk", Random.Range(0,5));
        yield return new WaitForEndOfFrameUnit();
        NPCWalkAni.SetInteger("walk", 0);
    }

    void npcIsRunning()
    {
        NPCWalkAni.SetInteger("idel", 0);
        NPCWalkAni.SetTrigger("run");
    }

    void npcHasStoppedWalking()
    {
        NPCWalkAni.SetInteger("idel", Random.Range(1, 3));
    }
}
