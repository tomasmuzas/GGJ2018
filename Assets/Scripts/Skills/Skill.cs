using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject, IDamageDealer
{
    public double Damage { get; private set; }
    public double Speed { get; set; }
}

