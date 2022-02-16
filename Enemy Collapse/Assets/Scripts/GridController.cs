using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] models;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject edge;
    private List<GameObject> grid;
    private List<GameObject> grid_with_path;

    void Start()
    {
        grid = new List<GameObject>();
        grid_with_path = new List<GameObject>();
        spawnGrid();
        setPathModel();
        clearGrid();
    }

    private void spawnGrid()
    {

        for (int i = 0; i < Level.levelData.WorldSize.y; i++)
        {
            for (int j = 0; j < Level.levelData.WorldSize.x; j++)
            {
                GameObject p;
                if (i == 0 || i == Level.levelData.WorldSize.y - 1 || j == 0 || j == Level.levelData.WorldSize.x - 1)
                {
                    p = Instantiate(edge);
                }
                else
                {
                    p = Instantiate(platform);
                    p.name = "emptyPlatform";
                }
                p.transform.position = new Vector3(i, 0, j);
                p.transform.SetParent(transform);
                grid.Add(p);
            }
        }
        transform.position = new Vector3(0 - Level.levelData.WorldSize.x / 2, 0, 0 - Level.levelData.WorldSize.y / 2);
    }

    private void setPathModel()
    {
        GameObject startObj = grid.Find(g => g.transform.position == Level.levelData.StartPoint);
        GameObject endObj = grid.Find(g => g.transform.position == Level.levelData.EndPoint);
        Vector3 currentPos = Level.levelData.StartPoint;

        foreach (var dir in Level.levelData.Path)
        {
            GameObject p = grid.Find(g => g.transform.position == currentPos);
            for (int i = 0; i < dir.magnitude; i++)
            {
                p = getNextDir(p, dir, grid);
                setModel(p, "platform");
            }
            currentPos += new Vector3(dir.x, 0, dir.y);
        }
        setModel(startObj, "portal");
        setModel(endObj, "tower");
    }
    private GameObject getNextDir(GameObject obj, Vector2 dir, List<GameObject> grid)
    {
        int index = grid.FindIndex(g => g == obj);
        GameObject g = null;
        switch (dir.normalized)
        {
            case Vector2 v when v.Equals(Vector2.right):
                g = grid[index + (int)Level.levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.up):
                g = grid[++index];
                break;
            case Vector2 v when v.Equals(Vector2.left):
                g = grid[index - (int)Level.levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.down):
                g = grid[--index];
                break;
        }
        if (g == null) return null;
        return g;
    }

    private void setModel(GameObject p, string type)
    {
        GameObject toSpawn = models[0];
        switch (type)
        {
            case "portal":
                toSpawn = models[1];
                break;
            case "tower":
                toSpawn = models[2];
                break;
        }
        GameObject np = Instantiate(toSpawn, p.transform);
        np.transform.SetParent(transform);
        grid_with_path.Add(np);
    }

    private void clearGrid()
    {
        foreach (GameObject p in grid) if (p.name == "emptyPlatform") Destroy(p);
    }
}
