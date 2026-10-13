using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leftRightDetect : MonoBehaviour
{
    [SerializeField]
    int triggerZone; // 1 = left, 2 = right
    public GameObject playerStandDisplay;
    int currentSceneIndex;
    void Start()
    {
        playerStandDisplay.SetActive(false);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    int currentDestination;
    void Update()
    {
        // Update the current destination based on the current scene
        if (currentSceneIndex == 1)
        {
            lvl1Movement lvl1MovementScript = FindObjectOfType<lvl1Movement>();
            currentDestination = lvl1MovementScript.distinationNum;
        } else
        {
            currentDestination = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // forklift scene, 1st 2 destinations player back cannot be against the wall, so hide the UI on the right side
            if (currentSceneIndex == 1 && (currentDestination == 0 || currentDestination == 1) && triggerZone == 2)
            {
                //CameraReset();
                playerStandDisplay.SetActive(false);
            }
            /* // forklift scene, turning right can only be done from the right side of the forkloft, so hide the UI on the left side
            else if (currentSceneIndex == 1 && currentDestination == 2 && triggerZone == 1)
            {
                playerStandDisplay.SetActive(false);
            }*/
            else
            {
                playerStandDisplay.SetActive(true);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // forklift scene, 1st 2 destinations player back cannot be against the wall, so hide the UI on the right side
            if (currentSceneIndex == 1 && (currentDestination == 0 || currentDestination == 1) && triggerZone == 2)
            {
                playerStandDisplay.SetActive(false);
            }
            /* // forklift scene, turning right can only be done from the right side of the forklift, so hide the UI on the left side
            else if (currentSceneIndex == 1 && currentDestination == 2 && triggerZone == 1)
            {
                playerStandDisplay.SetActive(false);
            }*/
            else
            {
                playerStandDisplay.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerStandDisplay.SetActive(false);
        }
    }
}