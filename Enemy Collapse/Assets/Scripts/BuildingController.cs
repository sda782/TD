using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] turrets;
    [SerializeField]
    private Tower tower;
    [SerializeField]
    private GameObject[] turrets_models;
    private int currentSelected;
    private Camera cam;
    private bool preview;
    private GameObject previewObj;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private TurretSO[] turretSOs;
    void Awake()
    {
        preview = false;
        cam = Camera.main;
        currentSelected = 0;
    }
    void Start()
    {
        tower = GameObject.Find("tower Variant(Clone)").GetComponent<Tower>();
        //turretSOs = (TurretSO[])Resources.LoadAll("Turrets", typeof(TurretSO));
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
        if (!canBuy()) return;
        Vector3 gridPos = new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z));
        Instantiate(turrets[currentSelected], gridPos, r);
        Buy();
    }
    public void SwitchBuilding()
    {
        currentSelected++;
        if (currentSelected == turrets.Length) currentSelected = 0;
        image.sprite = sprites[currentSelected];
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
    public void StopPlacement()
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
    private bool canBuy()
    {
        return turretSOs[currentSelected].Cost <= tower.Coins;
    }

    private void Buy()
    {
        tower.RemoveCoins(turretSOs[currentSelected].Cost);
    }
}
