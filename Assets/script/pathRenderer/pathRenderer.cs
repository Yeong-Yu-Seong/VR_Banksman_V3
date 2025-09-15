using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathRenderer : MonoBehaviour
{
    public List<Transform> endpoint = new List<Transform>();
    public Transform ForkLift;/*
    [SerializeField] private Transform playerCamera;*/
    [SerializeField] private GameObject startPoint;
    [SerializeField] private LineRenderer Path;
    [SerializeField] private float pathHeightOffset = 1.25f;
    [SerializeField] private float spawnHeightOffset = 1.5f;
    [SerializeField] private float pathUpdateSpeed = 0.25f;

    private NavMeshTriangulation triangulation;
    private Coroutine drawPathCoroutine;

    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();
    }

    private void Start()
    {
        gameEvents.current.onCurrentSequence += updadeSequence;
        drawPathCoroutine = StartCoroutine(drawPathToEndPoint());
    }
    int targetEndPoint;
    void updadeSequence(int newSequence)
    {
        targetEndPoint = newSequence;
    }
    private IEnumerator drawPathToEndPoint()
    {
        WaitForSeconds wait = new WaitForSeconds(pathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (endpoint[targetEndPoint] != null)
        {

            if (NavMesh.CalculatePath(startPoint.transform.position, endpoint[targetEndPoint].transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * pathHeightOffset);
                }
            }

            else
            {
                Debug.LogError("Unable to calculate a path");
            }

            yield return wait;
        }
    }

    private void Update()
    {
        startPoint.transform.position = new Vector3(ForkLift.transform.position.x, -0.998f, ForkLift.transform.position.z);

    }
}
