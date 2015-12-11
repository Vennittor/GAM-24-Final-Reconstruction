using UnityEngine;
using System.Collections;

public class Banana : ItemBaseScript
{
	bool canSlip = false;

	// Use this for initialization
	public override void Start () 
	{
        damage = 3;
        knockBack = .5f;
		durability = 1;
		base.Start();
	}
	public override void Update () 
	{
		
		base.Update();
	}
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        Released(throwDirection);
        base.FunctionAlpha(throwDirection);
    }
    public void FunctionBeta (GameObject player)
	{
        player.gameObject.GetComponent<DisabledStates>().AbilityLock(1.0f);
        AddDamage(player);
        durability--;
		base.FunctionBeta ();
	}
	void OnCollisionEnter(Collision other)
	{
		if(thrown)
		{
			if (other.gameObject.tag == "Floor")
			{
				canSlip = true;
			}
			if (canSlip)
			{
				if (other.gameObject.GetComponent<BaseCharacter>())
				    FunctionBeta(other.gameObject);
			}

		}
	}
}
