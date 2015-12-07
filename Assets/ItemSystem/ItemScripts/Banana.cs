using UnityEngine;
using System.Collections;

public class Banana : ItemBaseScript
{
	bool canSlip = false;

	// Use this for initialization
	public override void Start () 
	{
		durability = 1;
		base.Start();
	}
	public override void Update () 
	{
		
		base.Update();
	}
	public override void FunctionAlpha ()
	{
		thrown = true;
		base.FunctionAlpha ();
	}
	public override void FunctionBeta ()
	{
		//make them prone
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
				//if (other is player)
				FunctionBeta();
			}

		}
	}
}
