using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Praeivis : MonoBehaviour
{
    public double Health = 2;
    public Sprite Sprite2;
    public int Points = 10;
    public bool Slavified = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Slavified)
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.tag == "Projectile")
        {
            Health -= other.gameObject.GetComponent<Skill>().Damage;
            if (Health <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Sprite2;
                // TODO: Animation/sound
                Destroy(other.gameObject);

                //GetComponent<Collider2D>().enabled = false;
                //Speed = 0;
                //anim.SetBool("Dies", true);
                //GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                //GetComponent<MexicanMoving>().enabled = false;
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<LevelManager>().AddScore(this);
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag == "SpawnPoint")
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<PraeivisMovement>().target.transform == other.transform)
        {
            Destroy(gameObject);
        }
    }
}
