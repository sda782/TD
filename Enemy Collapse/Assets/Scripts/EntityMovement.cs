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
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, from + ConvertV(Level.levelData.Path[step]), Time.deltaTime * moveSpeed);
        if (transform.position == from + ConvertV(Level.levelData.Path[step]))
        {
            from += ConvertV(Level.levelData.Path[step]);
            step++;
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
}
