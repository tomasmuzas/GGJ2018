using System;
using UnityEngine;

public enum Direction
{
    Left, Right
}

public enum ShootingType
{
    Skill, PowerUp
}

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable, IHuman {
    
    private Direction direction;
    public GameObject PowerUp;
    public GameObject SkillPrefab;


    [SerializeField]
    public int HP{ get; private set; }
    public float Speed { get; set; } 

    private new Rigidbody2D rigidbody;

    public void Shoot()
    {
        if(SkillPrefab != null)
        {
            Instantiate(SkillPrefab, transform.position, transform.rotation);
            SpriteRenderer projectileSprite = SkillPrefab.GetComponent<SpriteRenderer>();
            Rigidbody2D projectileRigidBody = SkillPrefab.GetComponent<Rigidbody2D>();
            if (projectileSprite != null && projectileRigidBody != null)
            {
                Skill skillScript = SkillPrefab.GetComponent<Skill>();
                projectileSprite.sprite = skillScript.ShootingSprite;
                skillScript.Move();
            }

        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        Speed = 1f;
    }

    private void Update()
    {
        Move();
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    public void Move()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        float horizontalSpeed = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }
}

