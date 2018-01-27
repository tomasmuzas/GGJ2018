using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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
            ReduceHealthBy(other.gameObject.GetComponent<Skill>().Damage);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "SpawnPoint")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<PraeivisMovement>().target.transform == other.transform)
        {
            Destroy(gameObject);
        }
    }

    public void ReduceHealthBy(double amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            OnTransformation();
        }
    }

    public void OnTransformation()
    {
        GameObject.Find("Main Camera").GetComponent<LevelManager>().AddScore(this);
        PlayTransformationSound();
        ChangeAnimation();
    }

    void PlayTransformationSound()
    {
        GetComponent<AudioSource>().Play();
    }

    void ChangeAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite2;
    }

}