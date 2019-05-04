using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlPl : MonoBehaviour
{
    NavMeshAgent playerAgent;
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GetInteraction();
        }
    }
    void GetInteraction()
    {
        Ray interacionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interacionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteract(playerAgent);
                Debug.Log("interakcja");
            }
            else
            {
                playerAgent.destination = interactionInfo.point;
                playerAgent.stoppingDistance = 0f; 
            }
        }
    }
}
