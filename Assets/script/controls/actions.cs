using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using Valve.VR.InteractionSystem;

public class actions : MonoBehaviour
{
    public SteamVR_Action_Vector2 movement;
    public float speed = 1;
    public TextMeshProUGUI movementInput;
    public TextMeshProUGUI topHands;
    public TextMeshProUGUI LHand;
    public TextMeshProUGUI RHand;
    public TextMeshProUGUI DHand;
    public TextMeshProUGUI farDisplay;
    public TextMeshProUGUI closeDisplay;
    public TextMeshProUGUI frontPalmL;
    public TextMeshProUGUI frontPalmR;
    private CharacterController chracterController;
    public GameObject playerCamera;
    private CharacterController characterController;
    /// <summary>
    /// command colliders display
    /// </summary>
    public GameObject upArrow, upArrowx2, downArrow, downArrowx2, leftArrow, rightArrow;

    public GameObject handFrontFaceL, handFrontFaceR, handBackFaceL, handBackFaceR, handUpFaceL, handUpFaceR, handDownFaceR, handDownFaceL;

    /// <summary>
    /// Coroutines
    /// </summary>
    private Coroutine frontComboCoroutine;
    private Coroutine forkComboCoroutine;

    private void Start()
    {
        chracterController = GetComponent<CharacterController>();
        gameEvents.current.onTopEnter += topEnter;
        gameEvents.current.onTopExit += topExit;
        gameEvents.current.onLeftEnter += leftEnter;
        gameEvents.current.onLeftExit += leftExit;
        gameEvents.current.onRightEnter += rightEnter;
        gameEvents.current.onRightExit += rightExit;
        gameEvents.current.onFrontEnter += frontPosition;
        gameEvents.current.onFrontExit += exitFront;
        gameEvents.current.onPalmDownL += LPalmIsDown;
        gameEvents.current.onPalmDownR += RPalmIsDown;
        gameEvents.current.onDownEnter += downEnter;
        gameEvents.current.onDownExit += downExit;
        gameEvents.current.onMiddleEnter += middleEnter;
        gameEvents.current.onMiddleExit += middleExit;
        gameEvents.current.onLWhistleButtonPress += operationL;
        gameEvents.current.onLWhistleButtonHold += emergencyL;
        gameEvents.current.onRWhistleButtonPress += operationR;
        gameEvents.current.onRWhistleButtonHold += emergencyR;
        gameEvents.current.onWinLevel += displayWin;
        slowDownCombo.Add(true);
        slowDownCombo.Add(false);
        slowDownCombo.Add(true);
        slowDownCombo.Add(false);
        slowDownCombo.Add(true);
        gameEvents.current.onLoseLevel += shutDownPlayer;
        gameEvents.current.onFarEnter += farEnter;
        gameEvents.current.onFarExit += farExit;
        gameEvents.current.onCloseEnter += closeEnter;
        gameEvents.current.onCloseExit += closeExit;
        gameEvents.current.onPalmFrontL += checkPalmFrontL;
        gameEvents.current.onPalmFrontR += checkPalmFrontR;
        gameEvents.current.onGiveInstruction += showInstuctions;
    }
    bool forkDown;
    int LPalm;
    int RPalm;
    int isMiddle;
    int isDown;
    bool isDownBool;
    int downNumber;
    bool isWhistlingL;
    bool isWhistlingR;
    bool isWhistlingHoldL;
    bool isWhistlingHoldR;
    public GameObject confettie;
    int isFar;
    int isClose;
    int isPalmFrontL;
    int isPalmFrontR;
    public Animator winDisplay;
    void checkPalmFrontL(int isFront)
    {
        isPalmFrontL = isFront;
        if (isFront == 0)
        {
            
            handFrontFaceL.SetActive(false);
            handBackFaceL.SetActive(false);
        }
        else if (isFront == 1)
        {
            handFrontFaceL.SetActive(false);
            handBackFaceL.SetActive(true);
        }
        else if (isFront == 2)
        {
            handFrontFaceL.SetActive(true);
            handBackFaceL.SetActive(false);
        }
        frontPalmL.text = isPalmFrontL.ToString();
    }
    void checkPalmFrontR(int isFront)
    {
        isPalmFrontR = isFront;
        if (isFront == 0)
        {
            handFrontFaceR.SetActive(false);
            handBackFaceR.SetActive(false);
        }
        else if (isFront == 1)
        {
            handFrontFaceR.SetActive(false);
            handBackFaceR.SetActive(true);
        }
        else if (isFront == 2)
        {
            handFrontFaceR.SetActive(true);
            handBackFaceR.SetActive(false);
        }
        frontPalmR.text = isPalmFrontR.ToString();
    }
    void middleEnter()
    {
        isMiddle++;
        if (isMiddle == 2)
            checkForkCombo();
    }
    void middleExit()
    {
        isMiddle--;
    }
    void downEnter()
    {
        downNumber++;
        isDown++;
        isDownBool = true;
        if (isDown == 2)
            checkForkCombo();
        if (downNumber == 1)
            downArrow.SetActive(true);
        else if (downNumber == 2)
            downArrowx2.SetActive(true);
    }
    void downExit()
    {
        downNumber--;
        isDown--;
        isDownBool = false;
        if (downNumber == 0)
            downArrow.SetActive(false);
        else if (downNumber == 1)
            downArrowx2.SetActive(false);
    }
    bool awaytowardsWhistle;
    void farEnter()
    {
        isFar++;
        farDisplay.text = isFar.ToString();
        if (isFar == 2)
            checkFrontCombo();
    }
    void farExit()
    {
        isFar--;
        farDisplay.text = isFar.ToString();
    }
    void closeEnter()
    {
        isClose++;
        closeDisplay.text = isClose.ToString();
        if (isClose == 2)
            checkFrontCombo();
    }

    int frontComboNum;
    bool isfront;
    int forkComboNum;
    void checkForkCombo()
    {
        if (!ismoving)
        {
            if (isMiddle == 2)
            {
                if (forkComboNum == 0)
                    awaytowardsWhistle = false;
                if (forkComboCoroutine != null)
                {
                    StopCoroutine(forkComboCoroutine);
                }
                forkComboCoroutine = StartCoroutine(forkComboWindow());
                forkComboNum++;
                if (LPalm == 1 && RPalm == 1)
                {
                    forkDown = false;
                }
                else if (LPalm == 2 && RPalm == 2)
                {
                    forkDown = true;
                }
            }
            else if (isDown == 2)
            {
                if (forkComboCoroutine != null)
                {
                    StopCoroutine(forkComboCoroutine);
                }
                forkComboCoroutine = StartCoroutine(forkComboWindow());
                forkComboNum++;
            }
            if (forkComboNum >= 2 && awaytowardsWhistle)
            {
                if (forkDown && awaytowardsWhistle)
                {
                    gameEvents.current.ForkUp(false);
                }
                else if (!forkDown && awaytowardsWhistle)
                {
                    gameEvents.current.ForkUp(true);
                }
                forkComboNum = 0;
                awaytowardsWhistle = false;
            }
        }
    }
    IEnumerator forkComboWindow()
    {
        yield return new WaitForSeconds(1.5f);
        forkComboNum = 0;
        awaytowardsWhistle = false;
        forkComboCoroutine = null;
    }
    void checkFrontCombo()
    {
        if(!ismoving)
        {
            if (isClose == 2)
            {
                if (frontComboNum == 0)
                    awaytowardsWhistle = false;
                if (frontComboCoroutine != null)
                {
                    StopCoroutine(frontComboCoroutine);
                }
                frontComboCoroutine = StartCoroutine(frontComboWindow());
                frontComboNum++;
                if (isPalmFrontL == 1 && isPalmFrontR == 1)
                {
                    isfront = true;
                }
                else if (isPalmFrontL == 2 && isPalmFrontR == 2)
                {
                    isfront = false;
                }
            }
            else if (isFar == 2)
            {
                if (frontComboCoroutine != null)
                {
                    StopCoroutine(frontComboCoroutine);
                }
                frontComboCoroutine = StartCoroutine(frontComboWindow());
                frontComboNum++;
            }
            if (frontComboNum >= 4 && awaytowardsWhistle)
            {
                if (isfront && awaytowardsWhistle)
                {   
                    gameEvents.current.awayMe();
                }
                else if (!isfront && awaytowardsWhistle)
                {
                    gameEvents.current.toMe();
                }
                frontComboNum = 0;
                awaytowardsWhistle = false;
            }
        }
    }
    IEnumerator frontComboWindow()
    {
        yield return new WaitForSeconds(1.5f);
        frontComboNum = 0;
        awaytowardsWhistle = false;
        frontComboCoroutine = null;
    }
    void closeExit()
    {
        isClose--;
        closeDisplay.text = isClose.ToString();
    }   
    void shutDownPlayer()
    {
        GetComponent<actions>().enabled = false;
    }
    bool firstWin;
    void displayWin()
    {
        confettie.SetActive(true);
        if(!firstWin)
            winDisplay.SetTrigger("win");
        firstWin = true;
    }
    void operationL(bool startMoving)
    {
        isWhistlingL = startMoving;
        if (startMoving!)
        {
            isWhistlingHoldL = false;
        }
        if (startMoving)
            awaytowardsWhistle = true;
    }
    void emergencyL()
    {
        isWhistlingHoldL = true;
    }

    void operationR(bool startMoving)
    {
        isWhistlingR = startMoving;
        if (isWhistlingR!)
        {
            isWhistlingHoldR = false;
        }
        if(startMoving)
            awaytowardsWhistle = true;
    }
    void emergencyR()
    {
        isWhistlingHoldR = true;
    }
    void LPalmIsDown(int isLPalmDown)
    {
        LPalm = isLPalmDown;
        if (isLPalmDown == 0)
        {
            handUpFaceL.SetActive(false);
            handDownFaceL.SetActive(false);
        }
        else if (isLPalmDown == 1)
        {
            handUpFaceL.SetActive(true);
            handDownFaceL.SetActive(false);
        }
        else if (isLPalmDown == 2)
        {
            handUpFaceL.SetActive(false);
            handDownFaceL.SetActive(true);
        }
    }
    void RPalmIsDown(int isRPalmDown)
    {
        RPalm = isRPalmDown;
        if (isRPalmDown == 0)
        {
            handUpFaceR.SetActive(false);
            handDownFaceR.SetActive(false);
        }
        else if (isRPalmDown == 1)
        {
            handUpFaceR.SetActive(true);
            handDownFaceR.SetActive(false);
        }
        else if (isRPalmDown == 2)
        {
            handUpFaceR.SetActive(false);
            handDownFaceR.SetActive(true);
        }
    }
    bool isFrontR;
    bool isFrontL;
    
    void frontPosition(bool isLeft)
    {
        if (isLeft)
        {
            isFrontL = true;
        }
        else
        {
            isFrontR = true;
        }
        
    }
    void exitFront(bool isLeft)
    {
        if (isLeft)
        {
            isFrontL = false;
        }
        else
        {
            isFrontR = false;
        }
    }
    private static List<bool> slowDownCombo = new List<bool>();

    int slowNum;
    IEnumerator comboEnd()
    {
        yield return new WaitForSeconds(1.5f);
        slowNum = 0;
    }
    public bool ismoving;
    int PalmScanTime;
    private void FixedUpdate()
    {
        // movement 
        //Debug.Log(awaytowardsWhistle);
        if(GameObject.Find("carDirectionCheckCamera") != null)
        {
            GameObject.Find("carDirectionCheckCamera").transform.rotation = playerCamera.transform.rotation;
        }

        if (movement.axis.magnitude > 0.2f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(movement.axis.x, 0, movement.axis.y));
            chracterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.18f, 0) * Time.deltaTime);
            movementInput.text = movement.axis.x.ToString() + " _ " + movement.axis.y.ToString();
            ismoving = true;
            frontComboNum = 0;
            PalmScanTime = 0;
        }
        else
        {
            ismoving = false;
            if (!isWhistlingL)
                isWhistlingHoldL = false;
            if (!isWhistlingR)
                isWhistlingHoldR = false;
            if (trnsEmStop)
            {
                if (isWhistlingHoldL || isWhistlingHoldR)
                {
                    gameEvents.current.emergencyStop();
                    awaytowardsWhistle = false;
                }
            }
            else if (trnsStop)
            {
                if (isWhistlingL || isWhistlingR)
                {
                    gameEvents.current.stopOps();
                    awaytowardsWhistle = false;
                }

            }
            if (trnsStart)
            {
                if (isWhistlingL || isWhistlingR)
                {
                    awaytowardsWhistle = false;
                    gameEvents.current.startOps();
                }
            }

            if ((!isLIn && !isRIn) || numHandsTop > 0)
                slowNum = 0;

            else if (isLIn || isRIn)
            {
                if (slowDownCombo[slowNum] == isDownBool)
                {/*
                Debug.Log("combo: " + slowNum);*/
                    StopCoroutine(comboEnd());
                    slowNum += 1;
                    StartCoroutine(comboEnd());
                }
            }
            if (slowNum == slowDownCombo.Count - 1)
            {
                awaytowardsWhistle = false;
                gameEvents.current.slowDown();
                slowNum = 0;
            }
            if (isRIn && numHandsTop == 1 && (isWhistlingL || isWhistlingR))
            {
                awaytowardsWhistle = false;
                gameEvents.current.turnRight();
            }
            if (isLIn && numHandsTop == 1 && (isWhistlingL || isWhistlingR))
            {
                awaytowardsWhistle = false;
                gameEvents.current.turnLeft();
            }
        }
    }
    int numHandsTop = 0;
    bool trnsStop;
    bool trnsStart;
    bool trnsEmStop;
    void topEnter()
    {
        slowNum = 0;
        numHandsTop += 1;
        topHands.text = numHandsTop.ToString();
        if (numHandsTop == 2)
        {
            upArrowx2.SetActive(true);
            trnsEmStop = true;
            trnsStop = false;
        }
        else if(numHandsTop == 1)
        {
            upArrow.SetActive(true);
            trnsEmStop = false;
            trnsStop = true;
        }
        if(numHandsTop == 0)
        {
            trnsEmStop = false;
            trnsStop = false;
        }
    }
    void topExit()
    {
        numHandsTop -= 1;
        topHands.text = numHandsTop.ToString();
        if (numHandsTop == 0)
            upArrow.SetActive(false);
        else if (numHandsTop == 1)
            upArrowx2.SetActive(false);
        if (numHandsTop < 2)
            trnsStop = false;
    }

    bool isLIn;
    bool isRIn;
    void leftEnter()
    {
        LHand.text = "1";
        isLIn = true;
        leftArrow.SetActive(true);
        if (isLIn && isRIn)
            trnsStart = true;
        else if (isLIn && numHandsTop == 1 && (isWhistlingL || isWhistlingR))
        {
            awaytowardsWhistle = false;
            gameEvents.current.turnLeft();
        }
    }
    void leftExit()
    {
        trnsStart = false;
        LHand.text = "0";
        isLIn = false;
        leftArrow.SetActive(false);
    }
    void rightEnter()
    {
        RHand.text = "1";
        
        isRIn = true;
        if (isLIn && isRIn)
            trnsStart = true;
        else if (isRIn && numHandsTop == 1 && (isWhistlingL || isWhistlingR))
        {
            awaytowardsWhistle = false;
            gameEvents.current.turnRight();
        }
        rightArrow.SetActive(true);

    }
    void rightExit()
    {
        trnsStart = false;
        RHand.text = "0";
        isRIn = false;
        rightArrow.SetActive(false);
    }
    public TextMeshProUGUI insturctiontext;
    public Animator insturctionAni;
    void showInstuctions(string outcome)
    {
        insturctionAni.SetTrigger("show");
        insturctiontext.text = outcome;
    }
}
