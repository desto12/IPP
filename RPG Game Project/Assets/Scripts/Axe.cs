using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IWeapon
{
    public int Dmg { get; set; }
    private Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    public void Attack()
    {
        Debug.Log(this.name + "atakuje");
        anim.SetBool("Attack", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HtDetectionWorks"+other.name);
        if (other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(this.Dmg);
        }
    }
}
