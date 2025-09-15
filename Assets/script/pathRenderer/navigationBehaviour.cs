
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class navigationBehaviour : MonoBehaviour
{/*
    [SerializeField] private Transform playerCamera;*/
    [SerializeField] private LineRenderer line;/*
    [SerializeField] private GameObject navigationTarget;*/
    public List<Transform> endpoint = new List<Transform>();
    private NavMeshSurface navMeshSurface;
    private NavMeshPath navMeshPath;

    [SerializeField] private GameObject navigationBase;

    private void Start()
    {
        navMeshPath = new NavMeshPath();
        navMeshSurface = navigationBase.transform.GetComponentInChildren<NavMeshSurface>();
        gameEvents.current.onCurrentSequence += updadeSequence;
    }
    int targetEndPoint;
    void updadeSequence(int newSequence)
    {
        targetEndPoint = newSequence;
    }
    private void Update()
    {
        if (navigationBase != null && navMeshSurface != null)
        {
            NavMesh.CalculatePath(gameObject.transform.position, endpoint[targetEndPoint].transform.position, NavMesh.AllAreas, navMeshPath);

            if (navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                line.positionCount = navMeshPath.corners.Length;
                line.SetPositions(navMeshPath.corners);
            }

            else
            {
                line.positionCount = 0;
            }

        }
    }
}
