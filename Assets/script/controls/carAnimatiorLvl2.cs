using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAnimatiorLvl2 : MonoBehaviour
{
    private void Start()
    {
        gameEvents.current.onCarForward += carAniForward;
        gameEvents.current.onStopOps += stopAniCar;
        gameEvents.current.onEmergencyStop += stopAniCar;
        gameEvents.current.onStartOps += startAniCar;
        gameEvents.current.onCanSeePlayer += playerInView;
        gameEvents.current.onCarBackward += carAniBackward;
    }

    public Animator carAni;
    float currentSpeed = 0;
    bool firstStart = true;
    public AudioSource startEngine, engine, moving;
    void outOfView()
    {
        gameEvents.current.giveInstruction("driver cannot see you");
    }
    void FixedUpdate()
    {
        carAni.SetFloat("speed", currentSpeed);
        if (!isMoving && currentSpeed != 0)
        {
            firstStart = true;
            if (currentSpeed > 0)
            {
                currentSpeed -= 0.01f;
            }
            else if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        else if (GetComponent<lvl2Movement>().oppIsStarted)
        {
            if (firstStart)
            {
                currentSpeed = .1f;
                firstStart = false;
            }
            if (currentSpeed < 1)
                currentSpeed *= 1.02f;
        }
    }
    bool isMoving;
    bool inView;
    void playerInView(bool cansee, bool ignore, bool ignore2)
    {
        inView = cansee;
    }
    void carAniForward()
    {
        if(inView)
        {
            engine.volume = .6f;
            isMoving = true;
        }
        else if (!inView)
            outOfView();
    }
    void carAniBackward()
    {
        if (inView )
        {
            gameEvents.current.giveInstruction("cannot move backwards");
        }

    }
    void stopAniCar()
    {
        if(inView)
        {
            isMoving = false;
            engine.volume = .2f;
            moving.Stop();
        }
        else if (!inView)
            outOfView();
    }
    bool turnKeys;
    void startAniCar()
    {
        if(inView && !turnKeys)
        {
            turnKeys = true;
            engine.Play();
            engine.volume = .2f;
            startEngine.Play();
        }
        else if (!inView)
            outOfView();
    }
}
