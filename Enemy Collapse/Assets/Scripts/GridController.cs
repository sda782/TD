using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Texture[] Textures;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject edge;
    private List<GameObject> grid;
    public List<GameObject> Grid { get => grid; set => grid = value; }
    [SerializeField]
    private TextureManager textureManager;

    void Start()
    {
        grid = new List<GameObject>();
        SpawnGrid();
        SetPath();
    }

    private void SpawnGrid()
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
                }
                p.transform.position = new Vector3(i, 0, j);
                p.transform.SetParent(transform);
                grid.Add(p);
            }
        }
        transform.position = new Vector3(0 - Level.levelData.WorldSize.x / 2, 0, 0 - Level.levelData.WorldSize.y / 2);
    }

    private void SetPath()
    {
        GameObject startObj = grid.Find(g => g.transform.position == Level.levelData.StartPoint);
        GameObject endObj = grid.Find(g => g.transform.position == Level.levelData.EndPoint);
        Vector3 currentPos = Level.levelData.StartPoint;
        foreach (var dir in Level.levelData.Path)
        {
            GameObject p = grid.Find(g => g.transform.position == currentPos);
            for (int i = 0; i < dir.magnitude; i++)
            {
                p = textureManager.SetPathTexture(p, dir);
            }
            currentPos += new Vector3(dir.x, 0, dir.y);
        }
        textureManager.SetTexture(startObj, 3);
        textureManager.SetTexture(endObj, 5);
    }



}
