using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public List<GameObject> npcSpawnArea = new List<GameObject>();
    public List<GameObject> junctions = new List<GameObject>();
    public List<GameObject> npcList = new List<GameObject>();
    bool canSpawn = true;
    public int SpawnCap;
    public int NPCAmmount;
    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(Delay());
            canSpawn = false;        
        }
    }
    int spawnAmmount;
    IEnumerator Delay()
    {
        spawnAmmount = Random.Range(1, 5);
        for (int i = 0; i < spawnAmmount; i++)
        {
            if(NPCAmmount < SpawnCap)
            {
                Instantiate(npcList[Random.Range(0,npcList.Count -1)], new Vector3(0, 0, 0), Quaternion.identity);
                NPCAmmount++;
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        canSpawn = true;
        
    }
}
