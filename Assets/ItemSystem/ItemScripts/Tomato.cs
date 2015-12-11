using UnityEngine;
using System.Collections;

public class Tomato : ItemBaseScript
{
   
    public override void Grabbed(GameObject owner)
    {
        owner.GetComponent<BaseCharacter>().health -= 50;
        durability = 0;
        base.Grabbed(owner);
    }
}
