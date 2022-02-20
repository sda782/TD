using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] turrets;
    private int currentSelected;
    void Awake()
    {
        currentSelected = 0;
    }
    public void PlaceTurret(Vector3 pos)
    {
        Vector3 gridPos = new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z));
        Instantiate(turrets[currentSelected], gridPos, turrets[currentSelected].transform.rotation);
    }
    public void SwitchBuilding()
    {
        currentSelected++;
        if (currentSelected == turrets.Length) currentSelected = 0;
        Debug.Log("s index : " + currentSelected);
    }
}
