using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaVision : MonoBehaviour
{
    private bool activated = true;
    public float activeTime = 2f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && activated)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.DecreaseHP();
            PlayTransformationSound();
            activated = false;
            StartCoroutine(ActivateAgain());
        }
    }

    void PlayTransformationSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public IEnumerator ActivateAgain()
    {
        yield return new WaitForSeconds(activeTime);
        activated = true;
    }
}
