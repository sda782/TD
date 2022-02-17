using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private bool canShoot;
    private float coolDownTimer;
    [SerializeField]
    public UnityEvent<GameObject> HitEnemy;
    void Awake()
    {
        cam = Camera.main;
        canShoot = true;
        coolDownTimer = 3f;
    }
    void Update()
    {
        if (canShoot == false)
        {
            Debug.Log("can shoot is false;" + coolDownTimer);
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer <= 0)
        {
            Debug.Log("can shoot is true;");
            canShoot = true;
            coolDownTimer = 3f;
        }

    }
    public void Shoot()
    {
        if (canShoot == false) return;
        canShoot = false;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                handleEnemy(hit);
            }
        }
    }
    private void handleEnemy(RaycastHit hit)
    {
        HitEnemy?.Invoke(hit.transform.parent.gameObject);
    }
}
