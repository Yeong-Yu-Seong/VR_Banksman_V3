using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPositionOfhands : MonoBehaviour
{

    public bool isLeft;
    void Update()
    {
        if(isLeft)
        {
            GameObject.Find("raycastSensorL").transform.position = transform.position;
            GameObject.Find("raycastSensorL").transform.position -= new Vector3(0,20,0);
            GameObject.Find("raycastSensorL").transform.rotation = transform.rotation;
        }
        else
        {
            GameObject.Find("raycastSensorR").transform.position = transform.position;
            GameObject.Find("raycastSensorR").transform.position -= new Vector3(0, 20, 0);
            GameObject.Find("raycastSensorR").transform.rotation = transform.rotation;
        }
            
    }
}
