using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager_Enemy : MonoBehaviour, IEnemy
{
    public float currentHealth, power, maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth<=0)
        {
            Die();
        }
    }

    // Update is called once per frame
    public void PerformAttack()
    {
        
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
