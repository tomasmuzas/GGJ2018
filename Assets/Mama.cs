using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mama : MonoBehaviour {
    public void RecalculatePath(Transform newTarget)
    {
        GetComponent<PraeivisMovement>().RecalculatePath(newTarget);
    }
}
