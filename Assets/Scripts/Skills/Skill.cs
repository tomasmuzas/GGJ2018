using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject, IDamageDealer
{
    public Sprite UISprite;
    public Sprite ShootingSprite;
    [SerializeField]
    private double _damage;
    public double Damage { get { return _damage; } private set { _damage = value; }}
    [SerializeField]
    private double _speed;
    public double Speed { get { return _speed; } private set { _speed = value; } }
}

