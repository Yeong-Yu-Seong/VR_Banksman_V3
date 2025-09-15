using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class forkLiftFinal : MonoBehaviour
{
    public NavMeshAgent FinalForky;
    public GameObject finalTarget;
    // Update is called once per frame
    void Update()
    {
        if (FinalForky.enabled == true)
            FinalForky.SetDestination(finalTarget.transform.position);
    }
}
