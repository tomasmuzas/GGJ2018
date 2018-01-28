using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    // Kompot gives 1 live
    // Saslik gives full life
    public bool GiveHealth;
    public int GivesHealths;

    // Vodka changes skill
    public bool GivesSkill;
    public GameObject NewSkill;

    // Kebab gives speed
    public bool GivesTime;
    public int TimeGiven;

    // Majo gives shotgun
    public bool GivesShotgun;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaySound();
            // set player stuff
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (GiveHealth)
            {
                player.IncreasHP(GivesHealths);
            }

            if (GivesShotgun)
            {
                player.GiveShotgun();
            }

            if (GivesTime)
            {
                GameObject.Find("Main Camera").GetComponent<LevelManager>().GiveTime(TimeGiven);
            }

            if (GivesSkill)
            {
                player.GiveSkill(NewSkill);
            }

            Destroy(gameObject);
        }
    }

    void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
