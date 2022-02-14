using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField]
    private LevelData levelData;
    private int step = 0;
    [SerializeField]
    private float moveSpeed;
    private Vector3 from;

    void Start()
    {
        transform.position = new Vector3(levelData.StartPoint.x, transform.position.y, levelData.StartPoint.z);
        from = levelData.StartPoint;
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, from + ConvertV(levelData.Path[step]), Time.deltaTime * moveSpeed);
        if (transform.position == from + ConvertV(levelData.Path[step]))
        {
            from += ConvertV(levelData.Path[step]);
            step++;
        }
        if (step == levelData.Path.Count)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 ConvertV(Vector2 dir)
    {
        return new Vector3(dir.x, 0, dir.y);
    }
}
