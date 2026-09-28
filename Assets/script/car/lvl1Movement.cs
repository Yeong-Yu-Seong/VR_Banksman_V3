using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lvl1Movement : MonoBehaviour
{
    public bool oppIsStarted;

    public List<GameObject> destinations = new List<GameObject>();
    public int distinationNum;
    public NavMeshAgent car;
    public int maxSpeed;
    public int slowSpeed;
    public int acceleration;
    public NavMeshAgent innerCarNav;
    public GameObject SuddenNPC;    
    Vector3 EStopPositioninnerCar = new Vector3();
    public Animator frontWheels;
    public Animator backWheelsDirection1;
    public Animator backWheelsDirection2;
    public Animator backWheel1;
    public Animator backWheel2;
    public Animator forkliftTop;
    public GameObject NavCut;
    private void Start()
    {
        gameEvents.current.onCarForward += carForward;
        gameEvents.current.onCarBackward += carBackward;
        gameEvents.current.onStartOps += startCar;
        gameEvents.current.onStopOps += stopCar;
        gameEvents.current.onCurrentSequence += updateSequenceNum;
        gameEvents.current.onTurnLeft += carLeft;
        gameEvents.current.onTurnRight += carRight;
        gameEvents.current.onIsStraight += isCurrentlyStraight;
        gameEvents.current.onEmergencyStop += emergencyStopCar;
        gameEvents.current.onForkUp += moveFork;
        gameEvents.current.onCanSeePlayer += playerInView;
        gameEvents.current.onForkIsInPlace += forkIsPlaced;
    }
    void startCar()
    {
    }
    bool canSee;
    void playerInView(bool isCanSee, bool isInBackNotBlindSpot, bool isInFrontNotBlindSpot)
    {
        canSee = isCanSee;
    }
    bool carIsEStopped = false;
    bool firstCapture = true;
    public GameObject stopCube;
    void notStarted()
    {
        gameEvents.current.giveInstruction("operation not started");
    }
    void emergencyStopCar()
    {
        if (canSee && oppIsStarted)
        {
            isMoving = false;
            innerCarNav.enabled = false;
            currentSpeed = 0;
            if (firstCapture)
                EStopPositioninnerCar = GameObject.Find("innerCar").transform.position;
            firstCapture = false;
            carIsEStopped = true;
            NavCut.transform.position = EStopPositioninnerCar;
            stopCar();
            GameObject.Find("innerCar").GetComponent<NavMeshAgent>().stoppingDistance = 0;
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 0;
        }
    }
    void isCurrentlyStraight()
    {
        wheelDirection = 0;
    }
    void updateSequenceNum(int newS)
    {
        distinationNum = newS;
        if(newS == 3)
        {
            SuddenNPC.SetActive(true);
        }
    }
    bool dedectLeft;
    bool dedectRight;
    int wheelDirection;
    void carLeft()
    {
        if(canSee)
        {
            if (distinationNum == 1)
            {
                gameEvents.current.carBackward();
                carBackward();
            }
            dedectLeft = true;
            wheelDirection = 1;
        }
    }
    void carRight()
    {
        if (canSee)
        {
            if (distinationNum == 2)
            {
                gameEvents.current.carBackward();
                carBackward();
            }
            dedectRight = true;
            wheelDirection = 2;
        }
    }
    public bool isMoving;
    void carBackward()
    {
        if (canSee && oppIsStarted)
        {
            if (distinationNum > 2)
                innerCarNav.enabled = true;
            firstCapture = true;
            NavCut.SetActive(false);
            if (forkIsUp && distinationNum != 3)
            {
                gameEvents.current.spinBackward();
                carIsEStopped = false;
                isMoving = true;
                car.speed = maxSpeed;
                innerCarNav.speed = maxSpeed;
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
        else if (canSee && !oppIsStarted)
            notStarted();
    }
    void carForward()
    {
        if (canSee && oppIsStarted)
        {
            firstCapture = true;
            NavCut.SetActive(false);
            if (forkIsUp && distinationNum == 3)
            {
                gameEvents.current.spinForward();
                carIsEStopped = false;
                isMoving = true;
                car.speed = maxSpeed;
                innerCarNav.speed = maxSpeed;
                GameObject.Find("innerCar").GetComponent<NavMeshAgent>().enabled = true;
            }
        }
        else if (canSee && !oppIsStarted)
            notStarted();
    }
    void stopCar()
    {
        if (canSee && oppIsStarted)
        {
            isMoving = false;
            car.speed = 0;
            innerCarNav.speed = 0;
            GameObject.Find("innerCar").GetComponent<NavMeshAgent>().stoppingDistance = 1;
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 1;
            forkliftTop.SetInteger("upDown", 0);
            forkDirection = 0;
            forkIsMoving = false;
            forkAudio.Stop();
            forkStartAudioCanPlay = true;
            if (forkStopAudioCanPlayed)
                forkStopAudio.Play();
            forkStopAudioCanPlayed = false;
        }
    }
    bool canGoTo2;
    bool canGoTo3;
    float currentSpeed =0;
    public bool forkisInPlace;
    public List<GameObject> goalDisplays = new List<GameObject>();
    void forkIsPlaced(bool inPlace)
    {
        forkisInPlace = inPlace;
    }

    public bool forkIsUp;
    public float forkSpeed = 0.01f;
    public GameObject forkObject;
    int forkDirection;
    bool forkIsMoving;
    bool isFinalForkDown;
    public AudioSource forkAudio,forkStopAudio;
    bool forkStopAudioCanPlayed, forkStartAudioCanPlay = true;
    void moveFork(bool isUp)
    {
        if (canSee && oppIsStarted && !forkisInPlace)
        {
            forkIsMoving = true;
            if (forkIsUp != isUp)
                StopCoroutine(forkUpDownDelay(isUp, false));
            forkIsUp = false;
            StartCoroutine(forkUpDownDelay(isUp, false));
            if(isUp)
                forkliftTop.SetInteger("upDown", 1);
            else
                forkliftTop.SetInteger("upDown", 2);
        }
        else if (canSee && !oppIsStarted)
            notStarted();
        if (!isUp && canSee && !isMoving && distinationNum >= 4)
        {
            StartCoroutine(forkUpDownDelay(false, true));
            forkliftTop.SetInteger("upDown", 2);
        }
    }
    IEnumerator forkUpDownDelay(bool isUp, bool finalTrigger)
    {
        if (forkDirection == 0)
        {
            if(forkStartAudioCanPlay)
                forkAudio.Play();
            forkStartAudioCanPlay = false;
            yield return new WaitForSeconds(0.5f);
            if (isUp)
                forkDirection = 1;
            else
                forkDirection = 2;
            if (finalTrigger)
            {
                isFinalForkDown = true;
            }
        }
        else
            gameEvents.current.giveInstruction("stop opperation first");
    }

    void FixedUpdate()
    {
        for (int i = 0; i < goalDisplays.Count; i++)
        {
            goalDisplays[i].SetActive(false);
            if (goalDisplays[i] != null && i == distinationNum)
                goalDisplays[i].SetActive(true);
            else if (distinationNum >= 4 )
            {
                goalDisplays[goalDisplays.Count - 1].SetActive(true);
            }
        }
        if (forkisInPlace && !isFinalForkDown && !forkIsMoving)
        {
            forkIsUp = true;
        }
        else if (isFinalForkDown)
        {
            forkIsUp = false;
            if (forkObject.transform.position.y >= 0.15f)
                forkObject.transform.position -= new Vector3(0, forkSpeed, 0);
        }
        if (distinationNum == 4 && !forkIsUp)
            gameEvents.current.winLevel();
        if (oppIsStarted)
        {
            if (forkIsMoving && forkObject.transform.position.y >= 0.06547427f && forkObject.transform.position.y <= 3)
            {
                //Debug.Log("moving");
                forkStopAudioCanPlayed = true;
                if (forkDirection ==1)
                {
                    forkObject.transform.position += new Vector3(0, forkSpeed, 0);
                }
                else if (forkDirection ==2)
                {
                    forkObject.transform.position -= new Vector3(0, forkSpeed, 0);
                }
            }
            else if(forkObject.transform.position.y < 0.06547427f && forkIsMoving)
            {
                stopCar();
                forkObject.transform.position = new Vector3(forkObject.transform.position.x, 0.066f, forkObject.transform.position.z);
            }
            else if (forkObject.transform.position.y > 3 && forkIsMoving)
            {

                forkIsMoving = false;
                forkObject.transform.position = new Vector3(forkObject.transform.position.x, 2.99f, forkObject.transform.position.z);
            }

            forkliftTop.SetInteger("direction", wheelDirection);
            backWheelsDirection1.SetInteger("direction", wheelDirection);
            backWheelsDirection2.SetInteger("direction", wheelDirection);
            
            if (innerCarNav.enabled == true)
            {
                innerCarNav.SetDestination(destinations[3].transform.position);
            }
            for (int i = 0; i < destinations.Count; i++)
            {
                if (destinations[i].GetComponent<level1Sequence>().targetNum == distinationNum)
                    destinations[i].SetActive(true);
                else
                    destinations[i].SetActive(false);
            }
            if (distinationNum == 3)
            {
                if (!isMoving)
                    StartCoroutine(part3Breaks());
            }
            else if (distinationNum == 1 && !isMoving)
                canGoTo2 = true;
            else if (distinationNum == 2 && isMoving)
                canGoTo3 = true;
            else if (distinationNum == 0)
                car.SetDestination(destinations[distinationNum].transform.position);
            if (canGoTo2 && dedectLeft)
                car.SetDestination(destinations[distinationNum].transform.position);
            if (canGoTo3 && dedectRight)
                car.SetDestination(destinations[distinationNum].transform.position);

            if (!dedectLeft && !dedectRight)
                StartCoroutine(straightWheels());
            else
                StopCoroutine(straightWheels());
            dedectLeft = false;
            dedectRight = false;
        }
    }
    // ===============  ANimation  ======================
    IEnumerator straightWheels()
    {
        yield return new WaitForSeconds(1);
        backWheelsDirection1.SetInteger("direction", 0);
        backWheelsDirection2.SetInteger("direction", 0);
    }
    
    IEnumerator part3Breaks()
    {
        yield return new WaitForSeconds(3);
        innerCarNav.enabled = true;
        car.enabled = false;
    }
}
