

using UnityEngine;

public class Metal : ItemBaseScript 
{
	public override void FunctionAlpha (Vector3 throwDirection = default(Vector3))
	{
		
		base.FunctionAlpha ();
	}
    public override void Grabbed(GameObject owner)
    {
       // owner.GetComponent<BaseCharacter>()
        durability = 0;
    }
    public override void Update ()
	{
		base.Update ();
	}
}
