using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tutorialHardCode : MonoBehaviour
{
    private void Start()
    {
        gameEvents.current.onWalktoTutorial += TMoveTo;
        gameEvents.current.onStartOps += TStart;
        gameEvents.current.onToMe += TForward;
        gameEvents.current.onAwayMe += TBackward;
        gameEvents.current.onStopOps += TStop;
        gameEvents.current.onEmergencyStop += TEStop;
        gameEvents.current.onTurnRight += TRight;
        gameEvents.current.onTurnLeft += TLeft;
        gameEvents.current.onForkUp += TForkUp;
        StartCoroutine(firstAudioPlay());
    }
    public List<string> tutorialHardCodeText = new List<string>();
    public TextMeshProUGUI tutorialHardCodeDisplay;
    public int tutorialStepNum;
    public Animator trainerAni;
    public GameObject exit;
    public GameObject front;
    public List<GameObject> slides = new List<GameObject>();
    public List<AudioSource> audioLines = new List<AudioSource>();
    public GameObject audios;
    IEnumerator firstAudioPlay()
    {
        yield return new WaitForSeconds(2.2f);
        audios.SetActive(true);
        audioLines[0].Play();
    }
    int audioNum;
    private void Update()
    {
        gameEvents.current.canSeePlayer(true, true, true);
        trainerAni.SetInteger("talking", Random.Range(1, 3));
        tutorialHardCodeDisplay.text = tutorialHardCodeText[tutorialStepNum];
        if (canPlayAudio)
            StartCoroutine(audioLoop());
    }
    void visualiser()
    {
        for(int i = 0; i < slides.Count; i++)
        {

            if (i == tutorialStepNum)
                slides[i].SetActive(true);
            else
                slides[i].SetActive(false);
        }
    }
    void changeAudio()
    {
        StopAllCoroutines();
        audioNum++;
        for (int i = 0; i < audioLines.Count; i++)
        {
            audioLines[i].Stop();
        }
        canPlayAudio = true;
    }
    void TMoveTo()
    {
        if (tutorialStepNum == 0)
        {
            changeAudio();
            tutorialStepNum++;
            StartCoroutine(helloAudio());
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
            
    }
    void TStart()
    {
        if (tutorialStepNum == 1)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    IEnumerator helloAudio()
    {
        yield return new WaitForSeconds(1.2f);
        changeAudio();
    }
    void TForward()
    {
        if (tutorialStepNum == 2)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TBackward()
    {
        if (tutorialStepNum == 3)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TStop()
    {
        if (tutorialStepNum == 4)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TEStop()
    {
        if (tutorialStepNum == 5)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TRight()
    {
        if (tutorialStepNum == 6)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TLeft()
    {
        if (tutorialStepNum == 7)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
    }
    void TForkUp(bool isUp)
    {
        if (tutorialStepNum == 8 && isUp)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
            }
        }
        if (tutorialStepNum == 9 && !isUp)
        {
            changeAudio();
            tutorialStepNum++;
            if (trainerAni != null)
            {
                trainerAni.SetInteger("tutorialPart", tutorialStepNum);
                visualiser();
                gameEvents.current.winLevel();
            }
        }
    }
    bool canPlayAudio = true;
    IEnumerator audioLoop()
    {
        canPlayAudio = false;
        for (int i = 0; i < audioLines.Count; i++ )
        {
            if(i == audioNum)
            {
                audioLines[i].Play();
            }
        }
        yield return new WaitForSeconds(15f);
        canPlayAudio = true;
    }
}
