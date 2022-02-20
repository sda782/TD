using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TD/Level")]
public class LevelSO : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }
    [field: SerializeField]
    public Vector2 WorldSize { get; set; }
    [field: SerializeField]
    public Vector3 StartPoint { get; set; }
    public Vector3 EndPoint
    {
        get
        {
            return FindEndPoint();
        }
    }

    private Vector3 FindEndPoint()
    {
        Vector2 sumVector = Vector2.zero;
        foreach (var dir in Path)
        {
            sumVector += dir;
        }
        return StartPoint + new Vector3(sumVector.x, 0, sumVector.y);
    }

    [field: SerializeField]
    public List<Vector2> Path { get; set; }

}
