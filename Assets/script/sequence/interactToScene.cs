using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class interactToScene : MonoBehaviour
{
    float totalTime = 3;
    float currentTime;
    public Slider timeDisaplay;
    public GameObject timeDisaplayPosition;
    public bool next;
    public bool back;
    public bool start;
    public bool instructionReplay;
    public Camera[] allCamera;
    public void Awake()
    {
        allCamera = Camera.allCameras;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "hand")
        {
            timeDisaplayPosition.SetActive(true);
            currentTime = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "hand")
        {

            currentTime += Time.deltaTime;
            if(!instructionReplay)
                timeDisaplay.value = currentTime / totalTime;
            else
                timeDisaplay.value = currentTime / (totalTime/3);
            timeDisaplayPosition.transform.position = other.transform.position;
            timeDisaplayPosition.transform.position += new Vector3(0,0.2f,0);
            if (currentTime >= totalTime && next)
            {
                for (var i = 0; i < allCamera.Length; i++)
                {
                    if (allCamera[i] != null)
                        allCamera[i].enabled = false;
                }
                Destroy(GameObject.Find("Player(Clone)"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (currentTime >= totalTime && back)
            {
                for (var i = 0; i < allCamera.Length; i++)
                {
                    if(allCamera[i]!=null)
                        allCamera[i].enabled = false;
                }
                Destroy(GameObject.Find("Player(Clone)"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
            }
            else if (currentTime >= totalTime && start)
            {
                for (var i = 0; i < allCamera.Length; i++)
                {
                    if (allCamera[i] != null)
                        allCamera[i].enabled = false;
                }
                Destroy(GameObject.Find("Player(Clone)"));
                SceneManager.LoadScene(0);
            }
            else if (currentTime >= (totalTime / 3) && instructionReplay)
            {
                timeDisaplay.value = 0;
                GameObject.Find("instructionAudio").GetComponent<AudioSource>().Play();
            }
            else if (currentTime >= totalTime)
            {
                for (var i = 0; i < allCamera.Length; i++)
                {
                    if (allCamera[i] != null)
                        allCamera[i].enabled = false;
                }
                Destroy(GameObject.Find("Player(Clone)"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "hand")
        {
            timeDisaplayPosition.SetActive(false);
            currentTime = 0;
            timeDisaplay.value = 0;
        }
    }
}
