using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startStop : MonoBehaviour
{

    bool inFOV;
    void Start()
    {
        gameEvents.current.onStartOps += carStart;
        gameEvents.current.onStopOps += carStop;
        gameEvents.current.onEmergencyStop += carStop;
        gameEvents.current.onCanSeePlayer += playerInView;
    }
    void playerInView(bool isCanSee, bool ignore, bool ignore2)
    {
        inFOV = isCanSee;
    }
    void carStart()
    {
        if(inFOV)
            StartCoroutine(startOpperations());
    }
    void carStop()
    {
        /*if (inFOV)
            StartCoroutine(stopOpperations());*/
    }
    IEnumerator startOpperations()
    {
        yield return new WaitForEndOfFrame();
        if(SceneManager.GetActiveScene().buildIndex == 1)
            GetComponent<lvl1Movement>().oppIsStarted = true;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            GetComponent<lvl2Movement>().oppIsStarted = true;
    }
    IEnumerator stopOpperations()
    {
        yield return new WaitForSeconds(1);
        if (SceneManager.GetActiveScene().buildIndex == 1)
            GetComponent<lvl1Movement>().oppIsStarted = false;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            GetComponent<lvl2Movement>().oppIsStarted = false;
    }

}
