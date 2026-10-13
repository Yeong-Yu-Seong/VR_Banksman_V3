using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class gameEvents : MonoBehaviour
{
    public static gameEvents current;
    private void Awake()
    {
        current = this;
    }

    // ==========   hand gesutures   ==========
    public event Action onTopEnter;
    public void TopEnter()
    {
        if(onTopEnter != null)
        {
            onTopEnter();
        }
    }
    public event Action onTopExit;
    public void TopExit()
    {
        if (onTopExit != null)
        {
            onTopExit();
        }
    }

    public event Action onLeftEnter;
    public void LeftEnter()
    {
        if (onLeftEnter != null)
        {
            onLeftEnter();
        }
    }
    public event Action onLeftExit;
    public void LeftExit()
    {
        if (onLeftExit != null)
        {
            onLeftExit();
        }
    }
    public event Action onRightEnter;
    public void RightEnter()
    {
        if (onRightEnter != null)
        {
            onRightEnter();
        }
    }
    public event Action onRightExit;
    public void RightExit()
    {
        if (onRightExit != null)
        {
            onRightExit();
        }
    }
    public event Action onDownEnter;
    public void DownEnter()
    {
        if (onDownEnter != null)
        {
            onDownEnter();
        }
    }
    public event Action onDownExit;
    public void DownExit()
    {
        if (onDownExit != null)
        {
            onDownExit();
        }
    }
    public event Action onMiddleEnter;
    public void MiddleEnter()
    {
        if (onMiddleEnter != null)
        {
            onMiddleEnter();
        }
    }
    public event Action onMiddleExit;
    public void MiddleExit()
    {
        if (onMiddleExit != null)
        {
            onMiddleExit();
        }
    }


    public event Action<bool> onLWhistleButtonPress;
    public void LWhistleButtonPress(bool isWHistle)
    {
        if (onLWhistleButtonPress != null)
        {
            onLWhistleButtonPress(isWHistle);
        }
    }

    public event Action onLWhistleButtonHold;
    public void LWhistleButtonHold()
    {
        if (onLWhistleButtonHold != null)
        {
            onLWhistleButtonHold();
        }
    }
    public event Action<bool> onRWhistleButtonPress;
    public void RWhistleButtonPress(bool isWHistle)
    {
        if (onRWhistleButtonPress != null)
        {
            onRWhistleButtonPress(isWHistle);
        }
    }

    public event Action onRWhistleButtonHold;
    public void RWhistleButtonHold()
    {
        if (onRWhistleButtonHold != null)
        {
            onRWhistleButtonHold();
        }
    }
    public event Action<int> onPalmDownL;
    public void palmDownL(int isPalmDown)
    {
        if (onPalmDownL != null)
        {
            onPalmDownL(isPalmDown);
        }
    }
    public event Action<int> onPalmDownR;
    public void palmDownR(int isPalmDown)
    {
        if (onPalmDownR != null)
        {
            onPalmDownR(isPalmDown);
        }
    }

    public event Action<int> onPalmFrontL;
    public void palmFrontL(int isPalmDown)
    {
        if (onPalmFrontL != null)
        {
            onPalmFrontL(isPalmDown);
        }
    }
    public event Action<int> onPalmFrontR;
    public void palmFrontR(int isPalmDown)
    {
        if (onPalmFrontR != null)
        {
            onPalmFrontR(isPalmDown);
        }
    }

    public event Action< bool> onFrontEnter;
    public void FrontEnter( bool isleft)
    {
        if (onFrontEnter != null)
        {
            onFrontEnter( isleft);
        }
    }
    public event Action<bool> onFrontExit;
    public void FrontExit(bool isLeft)
    {
        if (onFrontExit != null)
        {
            onFrontExit(isLeft);
        }
        
    }
    public event Action onFarEnter;
    public void FarEnter()
    {
        if (onFarEnter != null)
        {
            onFarEnter();
        }
    }
    public event Action onFarExit;
    public void FarExit()
    {
        if (onFarExit != null)
        {
            onFarExit();
        }
    }
    public event Action onCloseEnter;
    public void CloseEnter()
    {
        if (onCloseEnter != null)
        {
            onCloseEnter();
        }
    }
    public event Action onCloseExit;
    public void CloseExit()
    {
        if (onCloseExit != null)
        {
            onCloseExit();
        }
    }
    public event Action<bool, bool, bool> onCanSeePlayer;
    public void canSeePlayer(bool isLeft, bool isback, bool isFront)
    {
        if (onCanSeePlayer != null)
        {
            onCanSeePlayer(isLeft, isback, isFront);
        }

    }
    public event Action<bool> onTooCloseToCar;
    public void tooCloseToCar(bool isWarned)
    {
        if (onTooCloseToCar != null)
        {
            onTooCloseToCar(isWarned);
        }

    }
    public event Action onToMe;
    public void toMe()
    {
        if (onToMe != null)
        {
            onToMe();
        }
    }
    public event Action onAwayMe;
    public void awayMe()
    {
        if (onAwayMe != null)
        {
            onAwayMe();
        }
    }
    // ==========   vehicle movements   ==========
    public event Action onStartOps;
    public void startOps()
    {
        if (onStartOps != null)
        {
            onStartOps();
        }
    }

    public event Action onStopOps;
    public void stopOps()
    {
        if (onStopOps != null)
        {
            onStopOps();
        }
    }

    public event Action onEmergencyStop;
    public void emergencyStop()
    {
        if (onEmergencyStop != null)
        {
            onEmergencyStop();
        }
    }
    public event Action onTurnRight;
    public void turnRight()
    {
        if (onTurnRight != null)
        {
            onTurnRight();
        }
    }
    public event Action onTurnLeft;
    public void turnLeft()
    {
        if (onTurnLeft != null)
        {
            onTurnLeft();
        }
    }
    public event Action<bool> onForkUp;
    public void ForkUp(bool isForkUp)
    {
        if (onForkUp != null)
        {
            onForkUp(isForkUp);
        }
    }
    public event Action onSlowDown;
    public void slowDown()
    {
        if (onSlowDown != null)
        {
            onSlowDown();
        }
    }
    public event Action onIsStraight;
    public void isStraight()
    {
        if (onIsStraight != null)
        {
            onIsStraight();
        }
    }
    public event Action onCarForward;
    public void carForward()
    {
        if (onCarForward != null)
        {
            onCarForward();
        }
    }
    public event Action onCarBackward;
    public void carBackward()
    {
        if (onCarBackward != null)
        {
            onCarBackward();
        }
    }
    public event Action<bool> onForkIsInPlace;
    public void forkIsInPlace(bool inPlace)
    {
        if (onForkIsInPlace != null)
        {
            onForkIsInPlace(inPlace);
        }
    }
    public event Action<string> onGiveInstruction;
    public void giveInstruction(string word)
    {
        if (onGiveInstruction != null)
        {
            onGiveInstruction(word);
        }
    }
    //==========   wheel animations for level 1   ==========
    public event Action onSpinForward;
    public void spinForward()
    {
        if (onSpinForward != null)
        {
            onSpinForward();
        }
    }
    public event Action onSpinBackward;
    public void spinBackward()
    {
        if (onSpinBackward != null)
        {
            onSpinBackward();
        }
    }
    // ==========   Sequence   ==========
    public event Action<int> onCurrentSequence;
    public void currentSequence(int sNum)
    {
        if (onCurrentSequence != null)
        {
            onCurrentSequence(sNum);
        }
    }
    public event Action onLoseLevel;
    public void levelReset()
    {
        if (onLoseLevel != null)
        {
            onLoseLevel();
        }
    }
    public event Action onWinLevel;
    public void winLevel()
    {
        if (onWinLevel != null)
        {
            onWinLevel();
        }
    }
    public event Action onNextLevel;
    public void nextLevel()
    {
        if (onNextLevel != null)
        {
            onNextLevel();
        }
    }
    public event Action onRestartLevel;
    public void restartLevel()
    {
        if (onRestartLevel != null)
        {
            onRestartLevel();
        }
    }
    public event Action<float, bool > onLvl2IntoDespawn;
    public void lvl2IntoDespawn(float NPCID, bool deleteNPC)
    {
        if (onLvl2IntoDespawn != null)
        {
            onLvl2IntoDespawn(NPCID, deleteNPC);
        }
    }
    public event Action onStopTraffic;
    public void stopTraffic()
    {
        if (onStopTraffic != null)
        {
            onStopTraffic();
        }
    }

    public event Action onWalktoTutorial;
    public void walktoTutorial()
    {
        if (onWalktoTutorial != null)
        {
            onWalktoTutorial();
        }
    }

    public event Action<string, int> onDeathScreenShow;
    public void deathScreenShow(string reason, int deathIndex)
    {
        if (onDeathScreenShow != null)
        {
            onDeathScreenShow(reason, deathIndex);
        }
    }
    // ==========   NPC Animate   ==========
    public event Action onNPCWalkAni;
    public void NPCWalkingAni()
    {
        if (onNPCWalkAni != null)
        {
            onNPCWalkAni();
        }
    }
    public event Action onScream;
    public void scream()
    {
        if (onScream != null)
        {
            onScream();
        }
    }
}
