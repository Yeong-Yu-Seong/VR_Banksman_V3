using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCheckFollow : MonoBehaviour
{
    //this things finds if the foreklift is turning for animation purpose
    //if "directionCheck" is touching one/two of these object, it is straight, else it is turing
    void Update()
    {
        transform.position = GameObject.Find("forkLiftLo").transform.position;
    }
}