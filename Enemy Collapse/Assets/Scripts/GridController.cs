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
        //setOutSideDecor();
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
                    p.transform.position = new Vector3(i, 0, j);
                    p.transform.SetParent(transform);
                    grid.Add(p);
                }
            }
        }
        transform.position = new Vector3(0 - Level.levelData.WorldSize.x / 2, 0, 0 - Level.levelData.WorldSize.y / 2);
    }

    private void setPathModel()
    {
        Vector3 currentPos = Level.levelData.StartPoint;
        if (Level.levelData.Path.Count > 0)
        {
            setModel(Level.levelData.StartPoint, "portal", grid_with_path);
            Vector3 p = Level.levelData.StartPoint;
            foreach (var dir in Level.levelData.Path)
            {
                for (int i = 0; i < dir.magnitude; i++)
                {
                    p = getNextDir(p, dir);
                    setModel(p, "platform", grid_with_path);
                }
                currentPos += new Vector3(dir.x, 0, dir.y);
            }
        }
        setModel(Level.levelData.EndPoint, "tower", grid_with_path);
    }
    private Vector3 getNextDir(Vector3 cur, Vector2 dir)
    {
        Vector3 next = cur;
        switch (dir.normalized)
        {
            case Vector2 v when v.Equals(Vector2.right):
                next += Vector3.right;
                break;
            case Vector2 v when v.Equals(Vector2.up):
                next += Vector3.forward;
                break;
            case Vector2 v when v.Equals(Vector2.left):
                next += Vector3.left;
                break;
            case Vector2 v when v.Equals(Vector2.down):
                next += Vector3.back;
                break;
        }
        return next;
    }

    private void setModel(Vector3 p, string type, List<GameObject> toAdd)
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
        GameObject np = Instantiate(toSpawn, p, toSpawn.transform.rotation);
        np.transform.SetParent(transform);
        toAdd.Add(np);
    }

    private void clearGrid()
    {
        foreach (GameObject p in grid) if (p.name == "emptyPlatform") Destroy(p);
        grid.RemoveAll(p => p.name == "emptyPlatform");
    }

    private void setOutSideDecor()
    {
        Instantiate(models[3], Vector3.left * Level.levelData.WorldSize.x, transform.rotation);
        Instantiate(models[3], Vector3.right * Level.levelData.WorldSize.x, transform.rotation);
        Instantiate(models[3], Vector3.forward * Level.levelData.WorldSize.y, transform.rotation);
        Instantiate(models[3], Vector3.back * Level.levelData.WorldSize.y, transform.rotation);
    }
}
