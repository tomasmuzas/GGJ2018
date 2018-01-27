using System;
using UnityEngine;

public enum Direction
{
    Left, Right
}


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable, IHuman {

    public Direction direction;
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
                skillScript.direction = this.direction;
                projectileSprite.sprite = skillScript.ShootingSprite;
                skillScript.Move();
            }

        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        Speed = 2f;
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

        Rotate(horizontalSpeed);

        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }

    public void Rotate(float horizontalSpeed)
    {
        direction = horizontalSpeed > 0 ? Direction.Right : Direction.Left;
        GetComponent<SpriteRenderer>().flipX = (direction == Direction.Left);
    }
}

