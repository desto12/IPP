using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;
    public Item axe;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        axe = new Item(1, "axe");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(axe);
        }
    }
}
