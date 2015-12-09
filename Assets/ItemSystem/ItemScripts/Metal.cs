

using UnityEngine;

public class Metal : ItemBaseScript 
{
	public override void FunctionAlpha (Vector3 throwDirection = default(Vector3))
	{
		
		base.FunctionAlpha ();
	}
    public override void Grabbed(GameObject owner)
    {
        //transform.parent.gameObject.GetComponent<>().MetalEffect();
    }
    public override void Update ()
	{
		base.Update ();
	}
}
