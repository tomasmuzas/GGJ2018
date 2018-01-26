using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Power Up")]
public class PowerUp : ScriptableObject, IDamageDealer{
    public Sprite UIIcon;
    public bool Enabled;
    public double Radius;
    public int durationInSeconds;

    [SerializeField]
    private DateTime _endTime;
    public DateTime EndTime { get { return _endTime; } private set { _endTime = value; } }

    [SerializeField]
    private double _damage;
    public double Damage { get { return _damage; } private set { _damage = value; } }

    void Start()
    {
        EndTime = DateTime.Now.AddSeconds(durationInSeconds);
    }
}
