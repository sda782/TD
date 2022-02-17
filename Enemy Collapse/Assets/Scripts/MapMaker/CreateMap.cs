using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    private LevelData newLevel;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private GameObject platform;
    private List<GameObject> grid;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        grid = new List<GameObject>();
        newLevel = (LevelData)ScriptableObject.CreateInstance("LevelData");
        newLevel.Name = "MapMaker";
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
                if (hit.transform.tag == "Placeable")
                {
                    Vector3 gridPos = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                    Instantiate(platform, gridPos, platform.transform.rotation);
                }
            }
        }
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
                    Debug.Log("b");
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
}
