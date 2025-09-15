using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NPCDeathAniCollider : MonoBehaviour
{
    public GameObject NPCAni;
    public GameObject Sight;
    public GameObject NPCparentController;
    public NavMeshAgent NPCNav;
    public Animator NPCAnimator;
    public List<GameObject> deathAudio = new List<GameObject>();
    public GameObject deathAudioPosition;
    bool isDead;
    private void Start()
    {
        gameEvents.current.onScream += hasScreamed;
    }
    void hasScreamed()
    {
        isDead = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "car" || other.transform.tag == "lvl1EndKillers") && other.GetComponent<lvl1NPC2Behaviour>() == null)
        {
            NPCAnimator.SetBool("dead", true);
            if (NPCparentController != null)
                Sight.GetComponent<npcSight>().NPCisDead = true;
            if (Sight != null)
            {
                Sight.GetComponent<npcSight>().NPCisDead = true;
                StartCoroutine(disableAnimator());
            }
            GetComponent<NPCDeathAniCollider>().enabled = false;
            if(NPCNav != null)
            {
                NPCNav.speed = 0;
                NPCNav.enabled = false;
            }
            if (transform.name == "RightCollider")
            {
                NPCAni.GetComponent<walkNPCController>().crashDirection = 2;
            }
            if (transform.name == "LeftCollider")
            {
                NPCAni.GetComponent<walkNPCController>().crashDirection = 1;
            }
            int selectedDeathAudio = Random.Range(0, deathAudio.Count);
            for (int i = 0; i < deathAudio.Count; i++)
            {
                if(i == selectedDeathAudio && !isDead)
                {
                    gameEvents.current.deathScreenShow("You have caused a casualty", 2);
                    gameEvents.current.scream();
                    Instantiate(deathAudio[i], deathAudioPosition.transform.position, Quaternion.identity);
                }
            }
        }
        IEnumerator disableAnimator()
        {
            yield return new WaitForEndOfFrameUnit();
            Sight.GetComponent<npcSight>().enabled = false;
        }
    }
}
