using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Map/Level")]
public class LevelData : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }
    [field: SerializeField]
    public Vector2 WorldSize { get; set; }
    [field: SerializeField]
    public Vector3 StartPoint { get; set; }
    [field: SerializeField]
    public Vector3 EndPoint { get; set; }
    [field: SerializeField]
    public List<Vector2> Path { get; set; }
}
