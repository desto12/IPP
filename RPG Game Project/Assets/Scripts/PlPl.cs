using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlPl : MonoBehaviour
{
    NavMeshAgent playerAgent;
    Animator anim;
    Rigidbody rigdBod;

    private Transform targetedEnemy;
    private bool isDancing = false;
    private Vector3 targetPosition;
    private bool clicked;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        rigdBod = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDancing = !isDancing;
            anim.SetBool("Dance", isDancing);
        }
        if (Input.GetButtonDown("Fire2") && isDancing == false)
        {
            GetInteraction();

        }
        else
            MoveAnimation();

    }
    void GetInteraction()
    {
        Ray interacionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interacionRay, out interactionInfo, 1000))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object" || interactedObject.tag == "Enemy")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteract(playerAgent);
                targetedEnemy = interactionInfo.transform;
                clicked = true;

            }

            else 
            {
                anim.SetBool("Attack", false);
                playerAgent.destination = interactionInfo.point;   
                playerAgent.stoppingDistance = 0f;
                clicked = false;
            }
        }
    }

    public void MoveAnimation()
    {
        if (!playerAgent.pathPending && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
        {
            if (clicked && targetedEnemy != null)
            {
                targetPosition = new Vector3(targetedEnemy.transform.position.x, transform.position.y, targetedEnemy.transform.transform.position.z);
                transform.LookAt(targetPosition);
            }

            anim.SetBool("Run", false);
        }
        else
        {

            anim.SetBool("Run", true);
        }
    }
}
