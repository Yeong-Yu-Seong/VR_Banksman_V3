using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class vehicleAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.current.onStartOps += startCar;
        gameEvents.current.onStopOps += stopCar;
        gameEvents.current.onEmergencyStop += emergencyStopCar;
        gameEvents.current.onTurnLeft += rotateLeft;
        gameEvents.current.onTurnRight += rotateRight;
        gameEvents.current.onLWhistleButtonPress += operationL;
        gameEvents.current.onLWhistleButtonHold += emergencyL;
        gameEvents.current.onRWhistleButtonPress += operationR;
        gameEvents.current.onRWhistleButtonHold += emergencyR;
        gameEvents.current.onPalmDownL += LPalmIsDown;
        gameEvents.current.onPalmDownR += RPalmIsDown;
        gameEvents.current.onForkUp += forkGoesUp;
        gameEvents.current.onSlowDown += slow;
        gameEvents.current.onCanSeePlayer += warningBlidSpot;
        gameEvents.current.onTooCloseToCar += warningTooCLose;
        gameEvents.current.onToMe += moveCarForward;
        gameEvents.current.onAwayMe += moveCarBackwards;
    }
    public GameObject isLWhistleDisplay;
    public GameObject isLWhistleHoldDisplay;
    public GameObject isRWhistleDisplay;
    public GameObject isRWhistleHoldDisplay;
    public TextMeshProUGUI actionDisplay;
    public GameObject UpPalm;
    public GameObject DownPalm;
    bool isWhistlingL;
    bool isWhistlingR;
    bool isWhistlingHoldL;
    bool isWhistlingHoldR;
    bool forkDown;
    int LPalm;
    int RPalm;
    public TextMeshProUGUI handLDisplay;
    public TextMeshProUGUI handRDisplay;
    public GameObject slowDisplay;

    public GameObject warningDisplay;
    public Animator actionDisplayAni;
    void displayText(string textDisplayed)
    {
        actionDisplay.text = textDisplayed;
        actionDisplayAni.SetTrigger("show");
    }
    void moveCarForward()
    {
        displayText("Travel Away From Me");
    }
    void moveCarBackwards()
    {
        displayText("Travel To Me");
    }
    void warningTooCLose(bool isWarned)
    {
        warningDisplay.SetActive(isWarned);
    }
    public GameObject isBlindStop;
    void warningBlidSpot(bool isBlind, bool ignore, bool ignore2)
    {
        isBlindStop.SetActive(!isBlind);
    }
    void slow()
    {
        StopCoroutine(slowDelete());
        slowDisplay.SetActive(true);
        StartCoroutine(slowDelete());
    }
    IEnumerator slowDelete()
    {
        yield return new WaitForSeconds(3);
        slowDisplay.SetActive(false);
    }
    void forkGoesUp(bool isUp)
    {   
        if (isUp)
            displayText("Fork up");
        else
            displayText("Fork down");
    }
    void LPalmIsDown(int isLPalmDown)
    {
        handLDisplay.text = isLPalmDown.ToString();
    }

    void RPalmIsDown(int isRPalmDown)
    {
        handRDisplay.text = isRPalmDown.ToString();
    }
    
    void operationL(bool startMoving) 
    {
        isLWhistleDisplay.SetActive(startMoving);
        isWhistlingL = startMoving;
        if(isWhistlingL!)
        {
            isWhistlingHoldL = false;
        }
    }
    void emergencyL()
    {
        isLWhistleHoldDisplay.SetActive(true);
        isWhistlingHoldL = true;
        StopCoroutine(removeHolddIS());
        StartCoroutine(removeHolddIS());
    }

    void operationR(bool startMoving)
    {
        isRWhistleDisplay.SetActive(startMoving);
        isWhistlingR = startMoving;
        if (isWhistlingR!)
        {
            isWhistlingHoldR = false;
        }
    }
    void emergencyR()
    {
        isRWhistleHoldDisplay.SetActive(true);
        isWhistlingHoldR = true;
        StopCoroutine(removeHolddIS());
        StartCoroutine(removeHolddIS());
    }
    IEnumerator removeHolddIS()
    {
        yield return new WaitForSeconds(3);
        isRWhistleHoldDisplay.SetActive(false);
        isLWhistleHoldDisplay.SetActive(false);
    }

    void startCar()
    {
        slowDisplay.SetActive(false);
        displayText("Start");
    }
    void stopCar()
    {
        slowDisplay.SetActive(false);
        displayText("Stop");
    }

    void emergencyStopCar()
    {
        displayText("Emergency stop");
    }
    void rotateLeft()
    {
        displayText("Left");
    }
    void rotateRight()
    {
        displayText("Right");
    }
}
