using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAnimatiorLvl1 : MonoBehaviour
{
    private void Start()
    {
        gameEvents.current.onCarForward += carAniForward;
        gameEvents.current.onCarBackward += carAniBackward;
        gameEvents.current.onStopOps += stopAniCar;
        gameEvents.current.onEmergencyStop += stopAniCar;
        gameEvents.current.onStartOps += startAniCar;
        gameEvents.current.onCanSeePlayer += playerInView;
        gameEvents.current.onForkIsInPlace += upForkCheck;
    }
    public Animator frokLiftTop;
    public Animator frontWheels;
    public Animator backWheel1;
    public Animator backWheel2;
    float currentSpeed = 0;

    // audio
    public AudioSource engineAudio, forkMoveAudio, startAudio; 
    void outOfView()
    {
        gameEvents.current.giveInstruction("driver cannot see you");
    }
    void forkIsNotUp()
    {
        gameEvents.current.giveInstruction("fork is not ready");
    }
    bool firstStart = true;
    void FixedUpdate()
    {

        frontWheels.SetFloat("speed", currentSpeed);
        backWheel1.SetFloat("speed", currentSpeed);
        backWheel2.SetFloat("speed", currentSpeed);
        if (currentSpeed < 0)
            currentSpeed = -currentSpeed;

        if (!isMoving && currentSpeed > 0)
        {
            currentSpeed -= 0.02f;
        }
        else if (!isMoving && currentSpeed <= 0)
            currentSpeed = 0;
        else if (isMoving && direction != 0)
        {
            if (firstStart)
            {
                currentSpeed = .1f;
                firstStart = false;
            }
            if (currentSpeed < .8)
                currentSpeed *= 1.02f;
        }
        if (direction == 2)
            currentSpeed = -currentSpeed;
    }
    bool isMoving;
    int direction;
    bool inView;
    bool isBackBlindSpot;
    bool isFrontBlindSpot;
    bool forkIsUp;
    void playerInView(bool cansee, bool isInBackBlindSpot, bool isInFrontBlindSpot)
    {
        inView = cansee;
        isBackBlindSpot = isInBackBlindSpot;
        isFrontBlindSpot = isInFrontBlindSpot;
    }
    void upForkCheck(bool forkUp)
    {
        forkIsUp = forkUp;
    }
    void carAniForward()
    {
        if(forkIsUp)
        {
            engineAudio.volume = 1f;
            if (isStart)
                frokLiftTop.SetTrigger("start");
            direction = 1;
            isMoving = true;
        }
        else if (!inView)
            outOfView();
        else if (!forkIsUp)
            forkIsNotUp();

    }
    void carAniBackward()
    {
        if(forkIsUp && isBackBlindSpot)
        {
            engineAudio.volume = 1f;
            if (isStart)
                frokLiftTop.SetTrigger("start");
            direction = 2;
            isMoving = true;
        }
        else if (!inView)
            outOfView();
        else if (!forkIsUp)
            forkIsNotUp();

    }
    void stopAniCar()
    {
        if(inView)
        {
            isMoving = false;
            engineAudio.volume = .1f;
            frokLiftTop.SetTrigger("stop");
            direction = 0;
        }
        else if (!inView)
            outOfView();

    }
    bool isStart;
    void startAniCar()
    {
        if(inView)
        {
            if (!isStart)
            {
                StartCoroutine(playStartSound());
                frokLiftTop.SetTrigger("start");
            }
            isStart = true;
            direction = 0;
        }
        else if (!inView)
            outOfView();
    }
    IEnumerator playStartSound()
    {
        yield return new WaitForSeconds(.5f);
        engineAudio.Play();
        startAudio.Play();
    }
}   
