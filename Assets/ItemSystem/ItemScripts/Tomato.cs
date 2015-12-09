using UnityEngine;
using System.Collections;

public class Tomato : ItemBaseScript
{
   
    public override void Grabbed(GameObject owner)
    {
        //add health
        durability = 0;
        base.Grabbed(owner);
    }
}
