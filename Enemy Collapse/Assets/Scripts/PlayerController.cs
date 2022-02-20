using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private bool canShoot;
    private float coolDownTimer;
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private ParticleSystem onhitps;
    [SerializeField]
    private Text reloading;
    void Awake()
    {
        cam = Camera.main;
        canShoot = true;
        coolDownTimer = 1.5f;
    }
    void Update()
    {
        if (canShoot == false)
        {
            coolDownTimer -= Time.deltaTime;
            reloading.text = "CD: " + coolDownTimer.ToString("F2");
            Debug.Log((1.5f / coolDownTimer));
        }
        if (coolDownTimer <= 0)
        {
            reloading.text = "CD: 0";
            canShoot = true;
            coolDownTimer = 1.5f;
        }

    }
    public void Shoot()
    {
        if (canShoot == false) return;
        canShoot = false;
        ps.Play();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            impactParticle(hit.point);
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<EnemyData>().TakeDamage(100);
            }
        }
    }

    private void impactParticle(Vector3 pos)
    {
        ParticleSystem ips = Instantiate(onhitps, pos, onhitps.transform.rotation);
        Destroy(ips, 100);
    }
}
