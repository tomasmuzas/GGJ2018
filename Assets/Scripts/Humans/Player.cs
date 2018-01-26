using UnityEngine;

public enum Direction
{
    Left, Right
}

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable, IHuman {
    
    private Direction direction;
    public PowerUp PowerUp { get; private set; }
    public Skill Skill { get; set; }

    [SerializeField]
    public int HP{ get; private set; }
    public float Speed { get; set; } 

    private new Rigidbody2D rigidbody;
    
    public void ApplyPowerUp(PowerUp newPowerUp)
    {
        PowerUp = newPowerUp;
    }

    public void ChooseSkill(Skill newSkill)
    {
        Skill = newSkill;
    }

    public void Shoot()
    {
        IDamageDealer damageDealer = PowerUp;
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
    }

    public void Move()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        float horizontalSpeed = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }
}
