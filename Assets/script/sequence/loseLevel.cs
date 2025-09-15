using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loseLevel : MonoBehaviour
{
    public bool hasLost = false;
    public GameObject winInteract;
    void Start()
    {
        gameEvents.current.onLoseLevel += deathCD;
        gameEvents.current.onWinLevel += winSequnce;
        gameEvents.current.onRestartLevel += winSequnce;
    }
    void deathCD()
    {

    }
    void winSequnce()
    {
        winInteract.SetActive(true);
    }


}
