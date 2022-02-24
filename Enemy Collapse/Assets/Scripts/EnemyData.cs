using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private EnemySO enemyType;
    private int HP;
    private int ATK;
    void Start()
    {
        if (enemyType == null) return;
        HP = enemyType.Health;
        ATK = enemyType.Attack;
    }
    public void SetType(EnemySO etype)
    {
        enemyType = etype;
        HP = enemyType.Health;
        ATK = enemyType.Attack;
    }

    public int Attack()
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
        Loot loot = GameObject.Find("WorldController").GetComponent<Loot>();
        loot.DropCoin(enemyType.DCoins);
        Level.NumberOfEnemies--;
        Destroy(transform.parent.gameObject);
    }
}
