using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySpawnCamera : MonoBehaviour
{
    public bool destroy;
    void Update()
    {
        if (destroy)
            Destroy(gameObject);
    }
}
