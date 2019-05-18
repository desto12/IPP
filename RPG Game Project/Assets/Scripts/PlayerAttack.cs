using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : Interactable
{
    public PlayerWeaponController weapon;
    public GameObject player;

    public override void Interact()
    {
        weapon = player.GetComponent<PlayerWeaponController>();
        Debug.Log("INTERKACJA Z ENEMY");
        weapon.PerformWeaponAttack();

    }


}
