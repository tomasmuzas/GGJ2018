using System;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Power Up")]
public class PowerUp : ScriptableObject, IDamageDealer{
    public bool Enabled;
    public double Radius;
    public int durationInSeconds;
    public DateTime EndTime { get; private set; }
    public double Damage { get; private set; }

    public PowerUp(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
        EndTime = DateTime.Now.AddSeconds(durationInSeconds);
    }
}
