using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranmaSpawn : MonoBehaviour {

    public GameObject GranmaPrefab;

    public GameObject[] Balconies;
    public float randStartTime = 0.5f;
    public float randEndTime = 1f;

    public List<GameObject> ActiveBalconies;

    void Start()
    {
        ActiveBalconies = new List<GameObject>();
        StartCoroutine(Spawn());
    }


    public IEnumerator Spawn()
    {
        // Get Random spawn point
        var balcony = Balconies[Random.Range(0, Balconies.Length - 1)];
        if (ActiveBalconies.Contains(balcony))
        {
            balcony = Balconies[Random.Range(0, Balconies.Length - 1)];
        }

        ActiveBalconies.Add(balcony);

        // Instantiate
        var granma = Instantiate(GranmaPrefab, balcony.transform.position, Quaternion.identity);

        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);
        StartCoroutine(Spawn());
        StartCoroutine(Dissapear(granma, balcony));
    }
    public IEnumerator Dissapear(GameObject granma, GameObject balcony)
    {
        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);
        ActiveBalconies.Remove(balcony);
        Destroy(granma);
    }
}
