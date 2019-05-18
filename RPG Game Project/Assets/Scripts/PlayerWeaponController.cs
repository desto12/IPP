using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform point;
    public GameObject playerHand;
    public GameObject EquipedWeapon { get; set; }
    IWeapon equippedWeapon;
    public void EquipWeapon(Item item)
    {
        if (EquipedWeapon != null)
        {
            Destroy(playerHand.transform.GetChild(1).gameObject);
        }
        EquipedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/"+item.ObjectSlug),
            point.position, point.transform.rotation);
        equippedWeapon = EquipedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Dmg = item.dmg;
        EquipedWeapon.transform.SetParent(playerHand.transform);

    }


    public void PerformWeaponAttack()
    {
        equippedWeapon.Attack();
    }
}