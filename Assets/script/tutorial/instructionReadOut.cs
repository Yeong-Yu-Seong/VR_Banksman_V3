using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionReadOut : MonoBehaviour
{
    public AudioSource instructionAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            instructionAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            instructionAudio.Stop();
        }
    }
}
