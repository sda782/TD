using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject platform;
    private List<GameObject> grid;
    private int x = 20, y = 20;
    void Start()
    {
        grid = new List<GameObject>();
        SpawnGrid();
    }

    private void SpawnGrid()
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject p = Instantiate(platform);
                p.transform.position = new Vector3(i, 0, j);
                p.transform.SetParent(transform);
                grid.Add(p);
            }
        }
        transform.position = new Vector3(0 - x / 2, 0, 0 - y / 2);
    }
}
