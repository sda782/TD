using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField]
    private LevelData levelData;
    private int step = 0;
    private float timeRemaining;
    [SerializeField]
    private float moveSpeed = 1;

    void Start()
    {
        transform.position = new Vector3(levelData.StartPoint.x, transform.position.y, levelData.StartPoint.z);
        timeRemaining = moveSpeed;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            return;
        }
        timeRemaining = moveSpeed;
        if (step == levelData.Path.Count)
        {
            step = 0;
            transform.position = new Vector3(levelData.StartPoint.x, transform.position.y, levelData.StartPoint.z);
        }
        transform.position += ConvertV(levelData.Path[step]);
        step++;

    }

    private Vector3 ConvertV(Vector2 dir)
    {
        return new Vector3(dir.x, 0, dir.y);
    }
}
