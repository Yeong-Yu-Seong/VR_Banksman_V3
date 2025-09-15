using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class banksmanFollow : MonoBehaviour
{
    public NavMeshAgent banksman2Nav;
    public GameObject car;
    public GameObject stopRoadTarget, lookAtTraffic, banksmanAni;
    public bool isStoppingTraffic;
    public bool thumbsUp;
    private void Start()
    {
        gameEvents.current.onStopOps += stopCar;
        gameEvents.current.onCurrentSequence += updateSequenceNum;
    }
    int destinationNum;
    bool stopTraffic;
    Vector3 startRotation_stop = new Vector3(0,0,0);
    float elaspedTime_stop;
    float lookTime_stop = 1;

    void stopCar()
    {
        if (destinationNum == 1)
            stopTraffic = true;
    }

    void updateSequenceNum(int num)
    {
        destinationNum = num;
    }
    Vector3 endlook = new Vector3(0,0,0);
    private void Update()
    {
        if(!thumbsUp)
        {
            if (!stopTraffic)
                banksman2Nav.SetDestination(car.transform.position);
            else
                banksman2Nav.SetDestination(stopRoadTarget.transform.position);
        }
        else
        {
            if(banksmanAni.GetComponent<thumbsUp>().isThumbsUp == false)
            {
                if (startRotation_stop == new Vector3(0, 0, 0))
                {
                    startRotation_stop = transform.eulerAngles;
                    stopRoadTarget.transform.LookAt(lookAtTraffic.transform);
                    endlook = stopRoadTarget.transform.eulerAngles;
                    endlook = new Vector3(0, endlook.y, 0);
                }
                elaspedTime_stop += Time.deltaTime;
                float percentTurned_stop = elaspedTime_stop / lookTime_stop;
                transform.eulerAngles = Vector3.Lerp(startRotation_stop, endlook, percentTurned_stop);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            else
            {
                transform.LookAt(GameObject.Find("HeadCollider").transform);
                transform.eulerAngles += new Vector3(0, 180, 0);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
        }

    }

}