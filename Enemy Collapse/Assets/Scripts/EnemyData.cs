using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private EnemySO enemyType;
    private int HP;
    private int ATK;
    void Start()
    {
        enemyType = EnemyManager.GetRandomEnemyType;
        HP = enemyType.Health;
        ATK = enemyType.Attack;
    }
    public int Attak()
    {
        return ATK;
    }
    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if (HP <= 0) Kill();
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
