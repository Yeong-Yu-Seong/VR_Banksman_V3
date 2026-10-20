using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level1Sequence : MonoBehaviour
{
    
    public int triggerNum;
    public int targetNum;
    public bool followX;
    public bool followZ;
    public GameObject car;
    public AudioSource itemCrash;
    
    private void Start()
    {
        if(triggerNum == 444)
            gameObject.SetActive(false);
    }
    private void Update()
    {
        
        if (followX)
        {
            transform.position = new Vector3(car.transform.position.x, transform.position.y, transform.position.z);
        }
        if (followZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, car.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "car")
        {   
            
            if(triggerNum == 444 || triggerNum == 445)
            {
                itemCrash.Play();
                FindObjectOfType<deathScreen>().displayDeathScreen("You did not stop the vehicle in time", 3);
                gameEvents.current.levelReset();
            }
            else
            {
                gameEvents.current.currentSequence(triggerNum);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "car")
        {
            if (triggerNum == 444 || triggerNum == 445)
            {
                if (itemCrash != null)
                FindObjectOfType<deathScreen>().displayDeathScreen("You did not stop the vehicle in time", 3);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}