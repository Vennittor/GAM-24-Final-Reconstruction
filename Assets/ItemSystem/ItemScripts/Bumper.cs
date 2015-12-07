using UnityEngine;
using System.Collections;

public class Bumper : ItemBaseScript 
{
	bool active = false;

	float bumperVelocity = 50;
	// Use this for initialization
	public override void Start () 
	{
		durability = 20;
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () 
	{

		base.Update();
	}
	public override void FunctionAlpha ()
	{

		base.FunctionAlpha ();
	}
	public override void FunctionBeta ()
	{
		active = true;
		thrown = false;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		base.FunctionBeta ();
	}
	void OnCollisionEnter(Collision other)
	{

			foreach (ContactPoint contact in other.contacts) 
			{
				Vector3 vect1;
				Vector3 vect2;

				if(contact.otherCollider.attachedRigidbody)
				{	
					vect2 = contact.otherCollider.attachedRigidbody.velocity;

					vect2.Normalize();
					
					vect1 = Vector3.Reflect(vect2, contact.normal);
					vect1.Normalize();
					if (thrown)
					{
						rb.AddForce(vect1 * bumperVelocity);
						FunctionBeta();
					}
					if(active)
					{
						contact.otherCollider.attachedRigidbody.AddForce(vect1 * bumperVelocity);
						durability--;
					}
				}
			}
	}


}
