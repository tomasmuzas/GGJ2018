using UnityEngine;

public class Mama : MonoBehaviour {

    public Transform target;

    private void Update()
    {
        GetComponent<PraeivisMovement>().RecalculatePath(target);
    }
}
