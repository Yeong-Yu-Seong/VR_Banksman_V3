using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class comandColliders : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "hand" && transform.name == "topCollider")
        {
            gameEvents.current.TopEnter();
        }
        if (other.transform.tag == "hand" && transform.name == "leftCollider")
        {
            gameEvents.current.LeftEnter();
        }
        if (other.transform.tag == "hand" && transform.name == "rightCollider")
        {
            gameEvents.current.RightEnter();
        }
        if (other.transform.tag == "hand" && transform.name == "downCollider")
        {
            gameEvents.current.DownEnter();
        }
        if (other.transform.tag == "hand" && transform.name == "farCollider")
        {
            gameEvents.current.FarEnter();
        }
        if (other.transform.tag == "hand" && transform.name == "nearCollider")
        {
            gameEvents.current.CloseEnter();
        }
        if (transform.name == "frontCollider" && other.transform.name == "vr_glove_left_model_slim(Clone)")
        {
            gameEvents.current.FrontEnter(true);
        }
        if (transform.name == "frontCollider" && other.transform.name == "vr_glove_right_model_slim(Clone)")
        {
            gameEvents.current.FrontEnter(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "hand" && transform.name == "topCollider")
        {
            gameEvents.current.TopExit();
        }
        if (other.transform.tag == "hand" && transform.name == "leftCollider")
        {
            gameEvents.current.LeftExit();
        }
        if (other.transform.tag == "hand" && transform.name == "rightCollider")
        {
            gameEvents.current.RightExit();
        }
        if (other.transform.tag == "hand" && transform.name == "downCollider")
        {
            gameEvents.current.DownExit();
        }
        if (other.transform.tag == "hand" && transform.name == "farCollider")
        {
            gameEvents.current.FarExit();
        }
        if (other.transform.tag == "hand" && transform.name == "nearCollider")
        {
            gameEvents.current.CloseExit();
        }
        if (transform.name == "frontCollider" && other.transform.name == "vr_glove_left_model_slim(Clone)")
        {
            gameEvents.current.FrontExit(true);
        }
        if (transform.name == "frontCollider" && other.transform.name == "vr_glove_right_model_slim(Clone)")
        {
            gameEvents.current.FrontExit(false);
        }
    }
}
