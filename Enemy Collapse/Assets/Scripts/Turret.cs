using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private EnemyManager enemyManager;
    private int lives = 10;
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemyManager.HitEnemy(col.gameObject);
            lives--;
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
