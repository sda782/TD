using System.Collections.Generic;
using System.Linq;
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
    private int numberofenemies = 10;
    void Start()
    {
        grid = new List<GameObject>();
        enemies = new List<GameObject>();
        SpawnGrid();
        SetPath();
        InvokeRepeating("spawnEnemies", 0.1f, 0.2f);
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
        foreach (var dir in levelData.Path)
        {
            GameObject p = grid.Find(g => g.transform.position == currentPos);
            for (int i = 0; i < dir.magnitude; i++)
            {
                p = SetPathTexture(p, dir);
            }
            currentPos += new Vector3(dir.x, 0, dir.y);
        }
        textureManager.SetTexture(startObj, 3);
        textureManager.SetTexture(endObj, 5);
    }

    private GameObject SetPathTexture(GameObject obj, Vector2 dir)
    {
        int index = grid.FindIndex(g => g == obj);
        GameObject g = null;
        switch (dir.normalized)
        {
            case Vector2 v when v.Equals(Vector2.right):
                g = grid[index + (int)levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.up):
                g = grid[++index];
                break;
            case Vector2 v when v.Equals(Vector2.left):
                g = grid[index - (int)levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.down):
                g = grid[--index];
                break;
        }
        if (g == null) return null;
        textureManager.SetTexture(g, 4);
        return g;
    }

    private void spawnEnemies()
    {
        if (amount == numberofenemies - 1) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemy);
        e.transform.SetParent(GameObject.Find("EnemyManager").transform);
        enemies.Add(e);
    }
}
