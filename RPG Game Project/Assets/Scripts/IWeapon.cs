using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    int Dmg{ get; set; }
    void Attack();
}
