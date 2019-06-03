using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager_Enemy : MonoBehaviour, IEnemy
{
    private NavMeshAgent navAgent;
    private Collider[] collider;
    private Player player;
    private Animator anim;

    public int dmg;
    public LayerMask aggroLayer;
    public float currentHealth, power, maxHealth;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {
        collider = Physics.OverlapSphere(transform.position, 10, aggroLayer);
        if (collider.Length > 0)
        {
            ChasePlayer(collider[0].GetComponent<Player>());
        }
    }
    // Start is called before the first frame update
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void ChasePlayer(Player player)
    {
        this.player = player;
        navAgent.SetDestination(player.transform.localPosition);
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            anim.SetBool("Run", false);
            if (!IsInvoking("PerformAttack"))
            {
                Debug.Log("Ok");
                InvokeRepeating("PerformAttack", .1f, 2f);
            }
        }
        else
        {
            CancelInvoke("PerformAttack");

        }
        
    }

    // Update is called once per frame
    public void PerformAttack()
    {
        player.TakeDamage(dmg);
        anim.SetBool("Attack", true);
        Debug.Log("Enemy Attackinfg");
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
