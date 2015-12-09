
using UnityEngine;

public class BunnyHood : ItemBaseScript 
{
    public override void FunctionBeta()
    {
        transform.parent = owner.transform;
        transform.position = owner.transform.position + new Vector3(0, .5f, 0);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //transform.parent.gameObject.GetComponent<>().BunnyEffect();
        // owner.GetComponent<Rigidbody>().mass = owner.GetComponent<Rigidbody>().mass / 2;
        base.FunctionBeta();
    }
    public override void Grabbed(GameObject owner)
    {
        FunctionBeta();
    }
    public override void Update ()
	{
		base.Update ();
	}
}
