using UnityEngine;

public class Mama : MonoBehaviour {
    
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        GetComponent<PraeivisMovement>().RecalculatePath(target.transform);
    }
}
