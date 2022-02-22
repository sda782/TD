using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TD/Turret")]
public class TurretSO : ScriptableObject
{
    [field: SerializeField]
    public int Health { get; set; }
    [field: SerializeField]
    public int Atk { get; set; }
    [field: SerializeField]
    public float AtkSpeed { get; set; }
    [field: SerializeField]
    public string TType { get; set; }
}
