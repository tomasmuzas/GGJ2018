using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraeivisSpawner : MonoBehaviour
{
    public float randStartTime = 0.5f;
    public float randEndTime = 1f;

    public GameObject[] PraeivisPrefabs;

    public GameObject[] Laiptines;
    public GameObject[] OffMaps;

    public GameObject MobileControls;

    void Start()
    {
        StartCoroutine(Spawn());
        //if (Application.platform != RuntimePlatform.Android)
        //{
        //    Destroy(MobileControls);
        //}
    }

	void Update () {
        if (Input.GetKeyDown("z"))
        {
            Spawn();
        }
    }

    public IEnumerator Spawn()
    {
        // From/to laiptine
        var toLaiptine = Random.value > 0.5f;
        // Get Random spawn point
        // Get Direction
        var laiptine = Laiptines[Random.Range(0, Laiptines.Length - 1)];
        var offMap = OffMaps[Random.Range(0, OffMaps.Length - 1)];

        GameObject SpawnPoint;
        GameObject Target;

        if (toLaiptine)
        {
            SpawnPoint = offMap;
            Target = laiptine;
        }
        else
        {
            SpawnPoint = laiptine;
            Target = offMap;
        }

        var praeivisPrefab = PraeivisPrefabs[Random.Range(0, PraeivisPrefabs.Length)];
        // Instantiate

        var praeivis = Instantiate(praeivisPrefab, SpawnPoint.transform.position, Quaternion.identity);
        praeivis.GetComponent<PraeivisMovement>().target = Target.transform;

        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);
        StartCoroutine(Spawn());
    }
}
