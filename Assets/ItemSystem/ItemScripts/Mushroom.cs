

using UnityEngine;

public class Mushroom : ItemBaseScript 
{
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        //mush effect
        durability = 0;
    }
    public override void Update ()
	{
		base.Update ();
	}
    public override void Grabbed(GameObject owner)
    {
        FunctionAlpha();
    }
}
