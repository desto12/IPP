using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string  nname;

    public override void Interact()
    {
        Debug.Log("Interakcja z NPC");
        DialogueSystem.Instance.AddNewDialogue(dialogue, nname);
    }
}
