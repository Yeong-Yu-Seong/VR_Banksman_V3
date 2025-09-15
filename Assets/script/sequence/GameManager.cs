using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public GameObject Player;
    void Start()
    {
        if (!GameObject.Find("Player") || GameObject.Find("Player(Clone)"))
        {
            Instantiate(Player, GameObject.Find("SPAWN").transform.position, Quaternion.identity);
        }
        DontDestroyOnLoad(GameObject.Find("Player(Clone)"));
    }
}
