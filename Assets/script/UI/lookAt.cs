using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    // Update is called once per frame
    public bool lockOnPlayerXZ;
    void Update()
    {
        transform.LookAt(GameObject.Find("HeadCollider").transform);
        if (!lockOnPlayerXZ)
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
