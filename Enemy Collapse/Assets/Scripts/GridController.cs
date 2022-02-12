using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject point;
    private List<GameObject> grid;
    void Start()
    {
        grid = new List<GameObject>();
        SpawnGrid();
    }

    private void SpawnGrid()
    {
        int x = 10, y = 10;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject p = Instantiate(point);
                p.transform.position = new Vector3(i, 0, j);
                grid.Add(p);
            }
        }
    }
}
