using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;
    public void PlaceTurret(Vector3 pos)
    {
        Vector3 gridPos = new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z));
        Instantiate(turret, gridPos, turret.transform.rotation);
    }
}
