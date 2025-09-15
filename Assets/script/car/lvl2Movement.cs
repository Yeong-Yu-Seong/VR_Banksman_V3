using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lvl2Movement : MonoBehaviour
{
    public bool oppIsStarted;

    public List<GameObject> destinations = new List<GameObject>();
    public int distinationNum;
    public NavMeshAgent car;
    public int maxSpeed;
    public int slowSpeed;
    public float acceleration;
    public Animator CarAni;
    public GameObject NavCut;
    public NavMeshAgent banksman2;

    void notStarted()
    {
        gameEvents.current.giveInstruction("opperation not started");
    }
    private void Start()
    {
        gameEvents.current.onCarForward += moveCar;
        gameEvents.current.onStartOps += startCar;
        gameEvents.current.onStopOps += stopCar;
        gameEvents.current.onEmergencyStop += emergencyStopCar;
        gameEvents.current.onCanSeePlayer += playerInView;
        gameEvents.current.onCurrentSequence += updateSequenceNum;
    }
    bool canSee;
    void playerInView(bool isCanSee, bool ignore, bool ignore2)
    {
        canSee = isCanSee;
    }
    bool carIsEStopped = false;
    void startCar()
    {
        if (canSee)
            car.enabled = true;
    }
    void emergencyStopCar()
    {
        if (canSee && oppIsStarted)
        {
            car.enabled = false;
            carIsEStopped = true;
            NavCut.transform.position = transform.position;
            NavCut.SetActive(true);
            stopCar();
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 0;
        }
        else if (canSee && !oppIsStarted)
            notStarted();
    }
    void updateSequenceNum(int newS)
    {
        distinationNum = newS;
    }
    public bool isMoving;
    void moveCar()
    {
        if (canSee && oppIsStarted)
        {
            NavCut.SetActive(false);
            carIsEStopped = false;
            isMoving = true;
            car.speed = maxSpeed;
        }
        else if (canSee && !oppIsStarted)
            notStarted();
    }
    void stopCar()
    {
        if (canSee && oppIsStarted)
        {
            isMoving = false;
            car.speed = (0);
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 1;
        }
        else if (canSee && !oppIsStarted)
            notStarted();
    }
    public List<GameObject> goalDisplays = new List<GameObject>();
    void FixedUpdate()
    {
        for (int i = 0; i < goalDisplays.Count; i++)
        {
            goalDisplays[i].SetActive(false);
            if (goalDisplays[i] != null && i == distinationNum)
                goalDisplays[i].SetActive(true);
            else
                goalDisplays[goalDisplays.Count - 1].SetActive(true);
        }
        if (distinationNum == 1 && !isMoving)
            banksman2.SetDestination(GameObject.Find("banksman2StopRoadTarget").transform.position);
        if (oppIsStarted)
        {
            car.SetDestination(destinations[0].transform.position);
            
                if (distinationNum == 2 && !isMoving)
                    gameEvents.current.winLevel();
        }
    }
}