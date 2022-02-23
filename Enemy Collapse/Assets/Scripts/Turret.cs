using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Turret : MonoBehaviour
{
    private int lives;
    private ParticleSystem ps;
    private ParticleSystem pshit;
    private List<GameObject> targetList;
    [SerializeField]
    private TurretSO turretSO;
    private float coolDown;
    void Start()
    {
        targetList = new List<GameObject>();
        ps = GetComponentInChildren<ParticleSystem>();
        coolDown = 0;
        lives = turretSO.Health;
    }

    void Update()
    {
        if (targetList.Count <= 0) return;
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            coolDown = turretSO.AtkSpeed;
            targetList.RemoveAll(g => g == null);
            Attack();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            targetList.Add(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            targetList.Remove(col.gameObject);
        }
    }

    private void Attack()
    {
        GameObject target = getNearest();
        if (target == null) return;
        ps.Play();
        EnemyData ed = target.GetComponent<EnemyData>();
        lives -= ed.Attack();
        ed.TakeDamage(turretSO.Atk);
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    private GameObject getNearest()
    {
        float maxDist = 100;
        GameObject nearestGameObject = null;
        foreach (var g in targetList)
        {
            float dist = Vector3.Distance(transform.position, g.transform.position);
            if (dist <= 100)
            {
                maxDist = dist;
                nearestGameObject = g;
            }
        }

        return nearestGameObject;
    }
}
