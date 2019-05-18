using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int dmg;
    public string ObjectSlug{ get; set; }

    public Item(int admg, string slug)
    {
        this.ObjectSlug = slug;
        this.dmg = admg;
        Debug.Log(this.ObjectSlug + this.dmg);
    }
}
