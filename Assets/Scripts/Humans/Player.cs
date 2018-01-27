using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
    private int _HP;
    public int HP{ get { return _HP; } set { _HP = value; } }
    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } set { _speed = value; } }


    private new Rigidbody2D rigidbody;

    public GameObject Mama = null;
    public HealthBar HealthBar { get; set; }

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
        HealthBar = GameObject.Find("HealthBarManager").GetComponent<HealthBar>();
        HealthBar.SetHp(HP);
    }


    private void Update()
    {
        Move();
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("x"))
        {
            Shoot();
        }
    }

    public void Move()
    {
        float verticalSpeed;
        float horizontalSpeed;
        if (Application.platform == RuntimePlatform.Android)
        {
            verticalSpeed = CrossPlatformInputManager.GetAxis("Vertical");
            horizontalSpeed = CrossPlatformInputManager.GetAxis("Horizontal");
        }
        else
        {
            verticalSpeed = Input.GetAxis("Vertical");
            horizontalSpeed = Input.GetAxis("Horizontal");
        }

        if (horizontalSpeed > 0)
        {
            FlipRight();
        }
        if (horizontalSpeed < 0)
        {
            FlipLeft();
        }

        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
        if (Mama != null)
        {
            Mama.GetComponent<Mama>().RecalculatePath(gameObject.transform);
        }
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Mama")
        {
            // TODO: Animation/sound
            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<LevelManager>().GameLose();
        }
    }

    public void DecreaseHP()
    {
        HP--;
        HealthBar.SetHp(HP);
    }
}

