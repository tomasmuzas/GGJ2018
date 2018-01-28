using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaSpawner : MonoBehaviour
{
    public GameObject MamaPrefab;

    public GameObject[] Laiptines;
    public GameObject Player;

    void Start()
    {
    }

	void Update () {
        if (Input.GetKeyDown("q"))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        // Get Random spawn point
        var laiptine = Laiptines[Random.Range(0, Laiptines.Length - 1)];

        var mama = Instantiate(MamaPrefab, laiptine.transform.position, Quaternion.identity);
        //Player.GetComponent<Player>().Mama = mama;
        mama.GetComponent<PraeivisMovement>().target = Player.transform;
    }
}
