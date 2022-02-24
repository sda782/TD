
using UnityEngine;

[CreateAssetMenu(menuName = "TD/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }
    [field: SerializeField]
    public int Health { get; set; }
    [field: SerializeField]
    public int Attack { get; set; }
    [field: SerializeField]
    public string EType { get; set; }
    [field: SerializeField]
    public int DCoins { get; set; }
}
