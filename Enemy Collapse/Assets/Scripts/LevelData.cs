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
    public int StartPoint { get => Path.FirstOrDefault(); }
    public int EndPoint { get => Path.LastOrDefault(); }
    [field: SerializeField]
    public List<int> Path { get; set; }
}
