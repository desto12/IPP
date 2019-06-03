using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHp;
    public float currHp;
    // Start is called before the first frame update
    void Start()
    {
        this.currHp = this.maxHp;
    }
    public void TakeDamage(int amount)
    {
        currHp -= amount;
        Debug.Log("Player takes dmg");
        if (currHp <= 0)
        {
            Debug.Log("Player i s dead");
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Playe is dead");
    }
}

