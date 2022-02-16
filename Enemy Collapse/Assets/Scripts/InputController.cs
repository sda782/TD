using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private GridController gridController;
    [SerializeField]
    public UnityEvent StartGame;
    [SerializeField]
    public UnityEvent<GameObject> HitEnemy;
    [SerializeField]
    private GameObject weaponStart;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private Level lvl;
    [SerializeField]
    private GameObject turrent;
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
        if (Input.GetKeyDown(KeyCode.N))
        {
            //switchLevel();
            Debug.Log("Fix it you noob");
        }

    }

    private void placeObj(RaycastHit hit)
    {
        Debug.Log("hit");
        Instantiate(turrent, hit.point, turrent.transform.rotation);
    }

    private void hideMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    private void switchLevel()
    {
        lvl.ChangeLevel();
    }

    private void handleEnemy(RaycastHit hit)
    {
        HitEnemy?.Invoke(hit.transform.parent.gameObject);
        //Destroy(hit.transform.parent.gameObject);
    }
}
