using UnityEngine;
using System.Collections;

public class Bumper : ItemBaseScript 
{
	bool active = false;
    GameObject holder;
	float bumperVelocity = 300;
	// Use this for initialization
	public override void Start () 
	{
        damage = 5;
        knockBack = 1;
		durability = 50;
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () 
	{
        if (held)
            GetComponent<CapsuleCollider>().enabled = false;
        else
            GetComponent<CapsuleCollider>().enabled = true;
        base.Update();
	}
	public override void FunctionAlpha (Vector3 throwDirection = default(Vector3))
	{
        Released(throwDirection);
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

                if (contact.otherCollider.attachedRigidbody)
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
                    if (active)
                    {
                        contact.otherCollider.attachedRigidbody.AddForce(vect1 * bumperVelocity);
                        if(other.gameObject.GetComponent<BaseCharacter>())
                            AddDamage(other.gameObject);
                        durability--;
                    }
                }
            }
        
	}


}
