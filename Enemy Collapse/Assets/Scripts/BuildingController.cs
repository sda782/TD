using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] turrets;
    [SerializeField]
    private GameObject[] turrets_models;
    private int currentSelected;
    private Camera cam;
    private bool preview;
    private GameObject previewObj;
    void Awake()
    {
        preview = false;
        cam = Camera.main;
        currentSelected = 0;
    }
    void Update()
    {
        if (preview) showPreview();
        if (preview && Input.GetKeyDown(KeyCode.R)) previewObj.transform.Rotate(Vector3.up, 90);
    }
    public void PlaceTurret(Vector3 pos)
    {
        if (previewObj == null) return;
        Quaternion r = previewObj.transform.rotation;
        StopPlacement();
        Vector3 gridPos = new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z));
        Instantiate(turrets[currentSelected], gridPos, r);
    }
    public void SwitchBuilding()
    {
        currentSelected++;
        if (currentSelected == turrets.Length) currentSelected = 0;
    }
    public void StartPreview()
    {
        preview = true;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.transform.tag == "Placeable")
            {
                Vector3 gridPos = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                previewObj = Instantiate(turrets_models[currentSelected], gridPos, turrets_models[currentSelected].transform.rotation);
                previewObj.layer = 2;
            }
        }
    }
    private void StopPlacement()
    {
        preview = false;
        Destroy(previewObj);
    }
    private void showPreview()
    {
        if (previewObj == null) return;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.transform.tag == "Placeable")
            {
                Vector3 gridPos = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                previewObj.transform.position = gridPos;
            }
        }
    }
}
