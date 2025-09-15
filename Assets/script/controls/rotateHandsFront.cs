using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHandsFront : MonoBehaviour
{
    private void Update()
    {
        GameObject.Find("RaycastL_Front").transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        GameObject.Find("RaycastR_Front").transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
