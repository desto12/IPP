using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlPl : MonoBehaviour
{
    NavMeshAgent playerAgent;
    Animator anim;
    Rigidbody rigdBod;
    private bool isDancing = false;
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
        if (Physics.Raycast(interacionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object" || interactedObject.tag == "Enemy")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteract(playerAgent);
            }

            else 
            {
                anim.SetBool("Attack", false);
                playerAgent.destination = interactionInfo.point;
                playerAgent.stoppingDistance = 0f;
            }
        }
    }

    public void MoveAnimation()
    {
        if (!playerAgent.pathPending && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
        {
            anim.SetBool("Run", false);
        }
        else
        {

            anim.SetBool("Run", true);
        }
    }
}
