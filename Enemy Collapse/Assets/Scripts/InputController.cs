using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    public UnityEvent StartGame;
    [SerializeField]
    public UnityEvent Shoot;
    [SerializeField]
    public UnityEvent SwitchBuilding;
    [SerializeField]
    public UnityEvent<Vector3> PlaceTurret;
    [SerializeField]
    public UnityEvent StartPlacement;
    [SerializeField]
    private GameObject menu;
    void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot?.Invoke();
        if (Input.GetMouseButtonDown(1)) StartPlacement?.Invoke();
        if (Input.GetMouseButtonUp(1)) rightClickHandler();
        if (Input.GetKeyDown(KeyCode.B)) StartGame?.Invoke();
        if (Input.GetKeyDown(KeyCode.X)) menu.SetActive(!menu.activeSelf); ;
        if (Input.GetKeyDown(KeyCode.L)) SceneManager.LoadScene("Menu");
        if (Input.GetKeyDown(KeyCode.N)) SwitchBuilding.Invoke();
    }


    private void rightClickHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.transform.tag == "Placeable")
            {
                PlaceTurret?.Invoke(hit.point);
            }
        }
    }
}
