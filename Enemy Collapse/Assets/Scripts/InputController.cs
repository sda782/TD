using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    public UnityEvent StartGame;
    [SerializeField]
    public UnityEvent<GameObject> HitEnemy;
    [SerializeField]
    public UnityEvent<Vector3> PlaceTurret;
    [SerializeField]
    private GameObject menu;
    void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "Enemy":
                        handleEnemy(hit);
                        break;
                    case "Placeable":
                        Debug.Log("can place");
                        placeObj(hit);
                        break;
                    default:
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartGame?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            hideMenu();
        }

    }

    private void placeObj(RaycastHit hit)
    {
        PlaceTurret?.Invoke(hit.point);
    }

    private void hideMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
    private void handleEnemy(RaycastHit hit)
    {
        HitEnemy?.Invoke(hit.transform.parent.gameObject);
    }
}
