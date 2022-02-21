using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    private LevelSO newLevel;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private InputField inputFieldName;
    [SerializeField]
    private GameObject platform;
    private List<GameObject> grid;
    private List<GameObject> paths;
    private Camera cam;
    private bool isStartPoint;
    private Vector3 currentPos;
    void Start()
    {
        isStartPoint = true;
        cam = Camera.main;
        grid = new List<GameObject>();
        paths = new List<GameObject>();
        newLevel = (LevelSO)ScriptableObject.CreateInstance("LevelSO");
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
                if (hit.transform.tag == "Road")
                {
                    int index = paths.FindIndex(g => g == hit.transform.gameObject);
                    for (int i = index; i < paths.Count; i++)
                    {
                        Destroy(paths[i]);
                        if (newLevel.Path.Count > 0) newLevel.Path.RemoveAt(index - 1);
                    }
                    paths.RemoveRange(index, paths.Count - index);
                    resetCurrentPos();
                }
                if (!checkIfInLine(currentPos, gridPos) && !isStartPoint) return;
                if (hit.transform.tag == "Placeable")
                {
                    GameObject g = Instantiate(platform, gridPos, platform.transform.rotation);
                    paths.Add(g);
                    if (isStartPoint)
                    {
                        newLevel.StartPoint = g.transform.position;
                        currentPos = newLevel.StartPoint;
                        isStartPoint = false;
                    }
                    else AddDirection(g);
                }
            }
        }
    }

    private void resetCurrentPos()
    {
        currentPos = newLevel.StartPoint;
        foreach (Vector2 p in newLevel.Path)
        {
            currentPos += new Vector3(p.x, 0, p.y);
        }
    }

    private void AddDirection(GameObject g)
    {
        Vector3 dir3 = g.transform.position - currentPos;
        currentPos += dir3;
        Vector2 dir = new Vector2(dir3.x, dir3.z);
        newLevel.Path.Add(dir);
    }
    public void PlayLevel()
    {
        MenuData.Level = newLevel;
        MenuData.Level.Path = newLevel.Path;
        SceneManager.LoadScene("SampleScene");
    }
    public void SaveLevel()
    {
        if (String.IsNullOrEmpty(inputFieldName.text)) return;
        newLevel.Name = inputFieldName.text;
        SaveLoad.SaveToFile(newLevel);
        SceneManager.LoadScene("Menu");

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
        if (int.Parse(inputField.text) % 2 != 0) return;
        newLevel.WorldSize = new Vector2(int.Parse(inputField.text), int.Parse(inputField.text));
        spawnGrid();
    }
    private bool OutSideBorder(Vector2 val)
    {
        return ((val.x <= -newLevel.WorldSize.x / 2 || val.x >= newLevel.WorldSize.x / 2))
        || ((val.y <= -newLevel.WorldSize.y / 2 || val.y >= newLevel.WorldSize.y / 2));
    }

    private bool checkIfInLine(Vector3 oldPos, Vector3 pos)
    {
        if (Vector3.Distance(oldPos, oldPos + Vector3.forward) + Vector3.Distance(pos, oldPos + Vector3.forward) == Vector3.Distance(oldPos, pos)) return true;
        if (Vector3.Distance(oldPos, oldPos + Vector3.left) + Vector3.Distance(pos, oldPos + Vector3.left) == Vector3.Distance(oldPos, pos)) return true;
        if (Vector3.Distance(oldPos, oldPos + Vector3.back) + Vector3.Distance(pos, oldPos + Vector3.back) == Vector3.Distance(oldPos, pos)) return true;
        if (Vector3.Distance(oldPos, oldPos + Vector3.right) + Vector3.Distance(pos, oldPos + Vector3.right) == Vector3.Distance(oldPos, pos)) return true;
        return false;
    }
}
