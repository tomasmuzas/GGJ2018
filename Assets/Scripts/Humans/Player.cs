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
            GameObject actualProjectile = Instantiate(SkillPrefab, transform.position, transform.rotation);
            SpriteRenderer projectileSprite = SkillPrefab.GetComponent<SpriteRenderer>();
            Skill skillScript = actualProjectile.GetComponent<Skill>();
            skillScript.direction = this.direction;
            projectileSprite.sprite = skillScript.ShootingSprite;
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

        if (horizontalSpeed > 0)
        {
            print(horizontalSpeed);
            FlipRight();
        }
        if (horizontalSpeed < 0)
        {
            print(horizontalSpeed);
            FlipLeft();
        }

        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }

    private void FlipLeft()
    {
        direction = Direction.Left;
        GetComponent<SpriteRenderer>().flipX = false;
    }

    private void FlipRight()
    {
        direction = Direction.Right;
        GetComponent<SpriteRenderer>().flipX = true;
    }


}

