using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour {

    public GameObject[] PowerUpPrefabs;

    public GameObject[] Places;
    public float randStartTime = 0.5f;
    public float randEndTime = 1f;

    public List<GameObject> ActivePlaces;
    // Use this for initialization
    void Start ()
    {
        ActivePlaces = new List<GameObject>();
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        // Get Random spawn point
        var place = Places[Random.Range(0, Places.Length - 1)];
        if (ActivePlaces.Contains(place))
        {
            place = Places[Random.Range(0, Places.Length - 1)];
        }

        ActivePlaces.Add(place);

        var powerupPrefab = PowerUpPrefabs[Random.Range(0, PowerUpPrefabs.Length)];

        // Instantiate
        var powerup = Instantiate(powerupPrefab, place.transform.position, Quaternion.identity);

        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);

        StartCoroutine(Spawn());
        StartCoroutine(Dissapear(powerup, place));
    }

    public IEnumerator Dissapear(GameObject powerup, GameObject place)
    {
        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);
        ActivePlaces.Remove(place);
        Destroy(powerup);
    }
}
