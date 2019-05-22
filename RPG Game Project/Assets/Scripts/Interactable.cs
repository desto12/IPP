using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool interacted;



    public virtual void MoveToInteract(NavMeshAgent playerAgent)
    {
        interacted = false;
        this.playerAgent = playerAgent; 
        playerAgent.stoppingDistance = 2.6f;
        playerAgent.destination = transform.position;
    }
    private void Update()
    {
        if (playerAgent != null && !playerAgent.pathPending)
        {

            if (!interacted && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                interacted = true;
            }
        }
    }

    public virtual void Interact()
    {

    }
}
    