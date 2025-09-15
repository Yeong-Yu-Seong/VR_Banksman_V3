using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    void Update()
    {
        transform.position = GameObject.Find("VRCamera").transform.position;
    }
}
