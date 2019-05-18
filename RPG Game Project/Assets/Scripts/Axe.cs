using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IWeapon
{
    public int Dmg { get; set; }

    public void Attack()
    {
        Debug.Log(this.name + "atakuje");
    }
}
