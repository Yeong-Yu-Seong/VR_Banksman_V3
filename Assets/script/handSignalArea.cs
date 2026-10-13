using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handSignalArea : MonoBehaviour
{
    public AudioSource insideAudio;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            insideAudio.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            insideAudio.Stop();
        }
    }
}
