using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whistleSoundDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfterAbit());
    }

    IEnumerator destroyAfterAbit()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
