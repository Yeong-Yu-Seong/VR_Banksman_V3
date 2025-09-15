using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forkliftKill : MonoBehaviour
{
    public GameObject LOFvolume;
    public GameObject EStop;
    public GameObject EStopLocation;
    public GameObject car;
    private void Start()
    {
    }
    bool isMoving;
    float speed;
    Vector3 lastPosition = Vector3.zero;
    private void Update()
    {
        speed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player" )
        {
            if (name == "warning")
            {

            }
            else if (name == "lineOfFire")
            {
                LOFvolume.SetActive(true);
            }
            else if (name == "killCollider")
            {
                if (speed!=0)
                {
                    EStop.SetActive(true);
                    EStop.transform.position = EStopLocation.transform.position;
                    gameEvents.current.levelReset();
                    gameEvents.current.deathScreenShow("You got ran over", 1);
                }
            }
                
        }
        if (other.transform.tag == "NPC" && name == "killCollider")
        {
            gameEvents.current.deathScreenShow("You have caused a casualty", 2);
            gameEvents.current.levelReset();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (name == "warning")
            {
                
            }
            else if (name == "lineOfFire")
            {
                LOFvolume.SetActive(false);
            }
        }
    }
}
