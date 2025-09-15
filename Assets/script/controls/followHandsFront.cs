using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followHandsFront : MonoBehaviour
{
    public bool targetLeftand;

    public GameObject handL;
    public GameObject handsR;

    // Update is called once per frame
    void Update()
    {
        if (targetLeftand)
        {
            transform.position = handL.transform.position;
        }
        else
        {
            transform.position = handsR.transform.position;
        }
    }
}
