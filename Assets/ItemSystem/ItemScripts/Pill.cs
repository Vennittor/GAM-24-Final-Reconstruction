using UnityEngine;

public class Pill : ItemBaseScript 
{
	public bool spawn = false;
	void Awake()
	{
		//spawner = base.spawner;
		durability = 1;
	}
	public override void Update()
	{
		if (spawn)
			FunctionBeta();
		base.Update();
	}
	public override void FunctionAlpha ()
	{
		//addforc in thrown direction
		thrown = true;

		base.FunctionAlpha ();
	}
	public override void FunctionBeta()
	{
		int chance = Random.Range (0,100);
		if (chance<=15)
		{
			//explode
		}
		else
		{
		ItemSelector select = spawner.GetComponent<ItemSelector>();
		GameObject a = Instantiate(select.SpawnItem(select.RandomDrop ()),
		                           transform.position,
		                           Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
		}
		durability --;
		base.FunctionBeta ();
	}
	void OnCollisionEnter(Collision other)
	{
		//if(hit by attack)
		//functionbeta
	}
}
