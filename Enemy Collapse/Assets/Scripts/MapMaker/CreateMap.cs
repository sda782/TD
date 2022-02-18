using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    private LevelData newLevel;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private InputField inputFieldName;
    [SerializeField]
    private GameObject platform;
    private List<GameObject> grid;
    private Vector3 lastPos;
    private Camera cam;
    private bool isStartPoint;
    void Start()
    {
        isStartPoint = true;
        cam = Camera.main;
        grid = new List<GameObject>();
        newLevel = (LevelData)ScriptableObject.CreateInstance("LevelData");
        newLevel.Path = new List<Vector2>();
    }
    void Update()
    {
        if (newLevel.WorldSize == null) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 gridPos = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                if (OutSideBorder(gridPos)) return;
                if (hit.transform.tag == "Placeable")
                {
                    GameObject g = Instantiate(platform, gridPos, platform.transform.rotation);
                    if (isStartPoint)
                    {
                        newLevel.StartPoint = g.transform.position;
                        lastPos = g.transform.position;
                        isStartPoint = false;
                    }
                    else
                    {
                        AddDirection(g);
                    }
                }
            }
        }
    }

    public void SaveLevel()
    {
        if (String.IsNullOrEmpty(inputFieldName.text)) return;
        newLevel.Name = inputFieldName.text;
        MenuData.Level = newLevel;
        SceneManager.LoadScene("SampleScene");
        //SaveLoad.SaveToFile(newLevel);
    }

    private void AddDirection(GameObject g)
    {
        Vector3 dir3 = lastPos - g.transform.position;
        Vector2 dir = new Vector2(dir3.x, dir3.z);
        newLevel.Path.Add(dir);
    }

    private void spawnGrid()
    {
        for (int i = 0; i < newLevel.WorldSize.y; i++)
        {
            for (int j = 0; j < newLevel.WorldSize.x; j++)
            {
                GameObject p;
                if (i == 0 || i == newLevel.WorldSize.y - 1 || j == 0 || j == newLevel.WorldSize.x - 1)
                {
                    p = Instantiate(platform);
                    p.transform.position = new Vector3(i, 0, j);
                    p.transform.SetParent(transform);
                    grid.Add(p);
                }
            }
        }
        transform.position = new Vector3(0 - newLevel.WorldSize.x / 2, 0, 0 - newLevel.WorldSize.y / 2);
    }
    public void SetWorldSize()
    {
        newLevel.WorldSize = new Vector2(int.Parse(inputField.text), int.Parse(inputField.text));
        spawnGrid();
    }
    private bool OutSideBorder(Vector2 val)
    {
        return ((val.x <= -newLevel.WorldSize.x / 2 || val.x >= newLevel.WorldSize.x / 2))
        || ((val.y <= -newLevel.WorldSize.y / 2 || val.y >= newLevel.WorldSize.y / 2));
    }
}
