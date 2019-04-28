using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public float attackDistance;
    public float attackRate;
    private float nextAttack;

    private NavMeshAgent navMeshAgent;
    private Animator anim;

    private Transform targetedEnemy;
    private bool walking;
    private bool enemyClicked;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "Enemy")
                {
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = hit.point;
                }
            }
        }

        if (enemyClicked)
        {
            MoveAndAttack();
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            walking = false;
        }
        else
            walking = true;
        anim.SetBool("Run", walking);
    }

    void MoveAndAttack()
    {
        if(targetedEnemy == null)
        {
            return;
        }

        navMeshAgent.destination = targetedEnemy.position;
        if(navMeshAgent.remainingDistance > attackDistance)
        {
            navMeshAgent.isStopped = false;
            Debug.Log("hited");
            walking = true;
        }
        else
        {
            transform.LookAt(targetedEnemy);
            Vector3 attackdir = targetedEnemy.transform.position - transform.position;

            if (Time.time > nextAttack) ;
            {
                nextAttack = Time.time + attackRate;
            }
            navMeshAgent.isStopped = true;
            walking = false;
        }
    }
}
