using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Praeivis : MonoBehaviour
{
    public double Health = 2;
    public Sprite Sprite2;

    void OnCollisionEnter2D(Collision2D other)
    {
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
