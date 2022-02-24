using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Tower tower;
    void Start()
    {
        tower = GameObject.Find("tower Variant(Clone)").GetComponent<Tower>();
    }
    public void DropCoin(int amount)
    {
        tower.AddCoins(amount);
    }
}
