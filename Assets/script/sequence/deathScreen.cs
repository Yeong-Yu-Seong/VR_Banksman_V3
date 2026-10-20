using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.current.onDeathScreenShow += displayDeathScreen;
    }
    public GameObject deathScreenObject;
    public TextMeshProUGUI reasonText;
    public List<string> tipListPlayer = new List<string>();
    public List<string> tipListNPC = new List<string>();
    public List<string> overShootList = new List<string>();
    public TextMeshProUGUI tip;
    bool isLost;
    public void displayDeathScreen(string reason, int index)
    {
        if (!isLost)
        {
            isLost = true;
            StartCoroutine(restartScene());
            deathScreenObject.SetActive(true);
            reasonText.text = reason;
            if (index == 1)
            {
                playeerDeath.Play();
                int selectedTip = Random.Range(0, tipListPlayer.Count);
                for (int i = 0; i < tipListPlayer.Count - 1; i++)
                {
                    if (i == selectedTip)
                        if (tipListPlayer[i] != null)
                            tip.text = tipListPlayer[i];
                        else
                            return;
                }
            }
            else if (index == 2)
            {
                int selectedTip = Random.Range(0, tipListNPC.Count);
                for (int i = 0; i < tipListNPC.Count; i++)
                {
                    if (i == selectedTip)
                        if (tipListNPC[i] != null)
                            tip.text = tipListNPC[i];
                        else
                            return;
                }
            }
            else if (index == 2)
            {
                int selectedTip = Random.Range(0, overShootList.Count);
                for (int i = 0; i < overShootList.Count; i++)
                {
                    if (i == selectedTip)
                        if (overShootList[i] != null)
                            tip.text = overShootList[i];
                        else
                            return;
                }
            }
            StartCoroutine(restartScene());
            deathScreenObject.SetActive(true);
            reasonText.text = reason;
            if (index == 1)
            {
                int selectedTip = Random.Range(0, tipListPlayer.Count);
                for (int i = 0; i < tipListPlayer.Count - 1; i++)
                {
                    if (i == selectedTip)
                        if (tipListPlayer[i] != null)
                            tip.text = tipListPlayer[i];
                        else
                            return;
                }
            }
            else if (index == 2)
            {
                int selectedTip = Random.Range(0, tipListNPC.Count);
                for (int i = 0; i < tipListNPC.Count; i++)
                {
                    if (i == selectedTip)
                        if (tipListNPC[i] != null)
                            tip.text = tipListNPC[i];
                        else
                            return;
                }
            }
            else if (index == 2)
            {
                int selectedTip = Random.Range(0, overShootList.Count);
                for (int i = 0; i < overShootList.Count; i++)
                {
                    if (i == selectedTip)
                        if (overShootList[i] != null)
                            tip.text = overShootList[i];
                        else
                            return;
                }


            }
            

        }

    }
    public AudioSource playeerDeath;
    public void Awake()
    {
        allCamera = Camera.allCameras;
    }
    public Camera[] allCamera;
    IEnumerator restartScene()
    {
        yield return new WaitForSeconds(7f);
        for (var i = 0; i < allCamera.Length; i++)
        {
            if (allCamera[i] != null)
                allCamera[i].enabled = false;
        }
        Destroy(GameObject.Find("Player(Clone)"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
