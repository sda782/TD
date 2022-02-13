using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Texture[] Textures;
    [SerializeField]
    private GameObject platform;
    private List<GameObject> grid;
    [SerializeField]
    private TextureManager textureManager;
    [SerializeField]
    private LevelData levelData;
    void Start()
    {
        grid = new List<GameObject>();
        SpawnGrid();
        SetPath();

    }

    private void SpawnGrid()
    {

        for (int i = 0; i < levelData.WorldSize.y; i++)
        {
            for (int j = 0; j < levelData.WorldSize.x; j++)
            {
                GameObject p = Instantiate(platform);
                p.transform.position = new Vector3(i, 0, j);
                p.transform.SetParent(transform);
                grid.Add(p);
            }
        }
        transform.position = new Vector3(0 - levelData.WorldSize.x / 2, 0, 0 - levelData.WorldSize.y / 2);
    }
    private void SetPath()
    {
        foreach (var item in levelData.Path)
        {
            textureManager.SetTexture(grid[item], 4);
        }
        textureManager.SetTexture(grid[levelData.StartPoint], 3);
        textureManager.SetTexture(grid[levelData.EndPoint], 5);
    }
}
