using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
    [SerializeField]
    private GameObject enemy;
    private List<GameObject> enemies;
    private int amount = 0;
    void Start()
    {
        grid = new List<GameObject>();
        enemies = new List<GameObject>();
        SpawnGrid();
        SetPath();
        InvokeRepeating("spawnEnemies", 0, 1f);
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
        GameObject startObj = grid.Find(g => g.transform.position == levelData.StartPoint);
        GameObject endObj = grid.Find(g => g.transform.position == levelData.EndPoint);
        Vector3 currentPos = levelData.StartPoint;
        foreach (var item in levelData.Path)
        {
            currentPos += new Vector3(item.x, 0, item.y);
            GameObject p = grid.Find(g => g.transform.position == currentPos);
            textureManager.SetTexture(p, 4);
        }
        textureManager.SetTexture(startObj, 3);
        textureManager.SetTexture(endObj, 5);
    }
    private void spawnEnemies()
    {
        if (amount == 0) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemy);
        enemies.Add(e);
    }
}
