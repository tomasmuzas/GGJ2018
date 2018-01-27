using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraeivisSpawner : MonoBehaviour
{

    public GameObject PraeivisPrefab;

    public GameObject[] Laiptines;
    public GameObject[] OffMaps;

	void Update () {
        if (Input.GetKeyDown("z"))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        // From/to laiptine
        var toLaiptine = Random.value > 0.5f;
        // Get Random spawn point
        // Get Direction
        var laiptine = Laiptines[Random.Range(0, Laiptines.Length - 1)];
        var offMap = OffMaps[Random.Range(0, Laiptines.Length - 1)];

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

        // TODO: Random praeivis type
        var praeivisPrefab = PraeivisPrefab;
        // Instantiate

        var praeivis = Instantiate(praeivisPrefab, SpawnPoint.transform.position, Quaternion.identity);
        praeivis.GetComponent<PraeivisMovement>().target = Target.transform;
    }
}
