
using UnityEngine;

public class BunnyHood : ItemBaseScript 
{
    public override void FunctionAlpha (Vector3 throwDirection = default(Vector3))
	{
        transform.parent = owner.transform;
        transform.position = owner.transform.position + new Vector3(0, .5f, 0);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //transform.parent.gameObject.GetComponent<>().BunnyEffect();
       // owner.GetComponent<Rigidbody>().mass = owner.GetComponent<Rigidbody>().mass / 2;

        base.FunctionAlpha ();
	}
    public override void Grabbed(GameObject owner)
    {
        FunctionAlpha();
    }
    public override void Update ()
	{
		base.Update ();
	}
}
