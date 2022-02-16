using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private int step = 0;
    [SerializeField]
    private float moveSpeed;
    private Vector3 from;

    void Start()
    {
        transform.position = new Vector3(Level.levelData.StartPoint.x, transform.position.y, Level.levelData.StartPoint.z);
        from = Level.levelData.StartPoint;
        faceDirection(ConvertV(Level.levelData.Path[step == Level.levelData.Path.Count ? 0 : step]));
    }

    void Update()
    {
        Vector2 dir = Level.levelData.Path[step];
        transform.position = Vector3.MoveTowards(transform.position, from + ConvertV(dir), Time.deltaTime * moveSpeed);
        if (transform.position == from + ConvertV(dir))
        {
            from += ConvertV(dir);
            step++;
            faceDirection(ConvertV(Level.levelData.Path[step == Level.levelData.Path.Count ? Level.levelData.Path.Count - 1 : step]));
        }
        if (step == Level.levelData.Path.Count)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 ConvertV(Vector2 dir)
    {
        return new Vector3(dir.x, 0, dir.y);
    }
    private void faceDirection(Vector2 dir)
    {
        transform.forward = Vector3.forward;
        transform.forward = ConvertV(dir).normalized;
    }
}
