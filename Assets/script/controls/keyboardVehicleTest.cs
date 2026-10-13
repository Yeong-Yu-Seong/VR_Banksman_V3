// Disable this script if you are using a VR headset. This script is for testing the vehicle controls when you do not have a VR headset.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardVehicleTest : MonoBehaviour
{
    frontBackDedect frontBackDetect;
    private void Start()
    {
        frontBackDetect = FindObjectOfType<frontBackDedect>();
        if (frontBackDetect != null)
        {
            // For Editor Testing
            frontBackDetect.isFacing = 1;
        } else {
            Debug.LogError("frontBackDetect script not found in the scene.");
        }
    }
    void Update()
    {
        // For Editor Testing
        frontBackDetect.isFacing = 1;
        // =========================
        // VEHICLE OPERATION
        // =========================

        // 1 = Start
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("KEYBOARD -> StartOps");
            gameEvents.current.startOps();
        }

        // 2 = Stop
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("KEYBOARD -> StopOps");
            gameEvents.current.stopOps();
        }

        // 3 = Emergency Stop
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("KEYBOARD -> EmergencyStop");
            gameEvents.current.emergencyStop();
        }


        // =========================
        // MOVEMENT
        // =========================

        // I = Forward
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("KEYBOARD -> To Me");
            gameEvents.current.toMe();
        }

        // K = Backward
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("KEYBOARD -> Away From Me");
            gameEvents.current.awayMe();
        }

        // J = Left
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("KEYBOARD -> TurnLeft");
            gameEvents.current.turnLeft();
        }


        // L = Right
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("KEYBOARD -> TurnRight");
            gameEvents.current.turnRight();
        }


        // =========================
        // FORKLIFT
        // =========================

        // 4 = Fork Up
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("KEYBOARD -> ForkUp");
            gameEvents.current.ForkUp(true);
        }

        // 5 = Fork Down
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("KEYBOARD -> ForkDown");
            gameEvents.current.ForkUp(false);
        }
    }
}
