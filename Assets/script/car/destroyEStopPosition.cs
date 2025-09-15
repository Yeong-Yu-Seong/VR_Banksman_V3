using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEStopPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.current.onStartOps += destroyCube;
    }
    void destroyCube()
    {
        Destroy(gameObject);
    }
    
}
