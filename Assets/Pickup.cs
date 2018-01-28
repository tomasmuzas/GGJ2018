using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool GiveHealth;
    public int GivesHealths;
    public bool GivesSkill;
    public GameObject NewSkill;
    // Vodke

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaySound();
            // set player stuff
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


            Destroy(gameObject);
        }
    }

    void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
