using UnityEngine;
using System.Collections;

public class ItemBaseScript : MonoBehaviour 
{
	public bool held = false;
	public bool thrown = false;

	public int damage = 1;
	public int thrownDMG = 5;

	public int durability = 1;

	public Rigidbody rb;

	public GameObject spawner;

	GameObject owner;
	// Use this for initialization
	public virtual void Start()
	{
		spawner = GameObject.Find("ItemSpawn");
		rb = GetComponent<Rigidbody>();
	}
	public virtual void Update()
	{
		if (durability <=0)
		{
			spawner.GetComponent<ItemSpawner>().itemsAwake.Remove(gameObject);
			Destroy(gameObject);
		}
	}
	public virtual void Grabbed(GameObject owner)
	{
		held = true;
		transform.parent = owner.transform;
	}
	public virtual void Released()
	{
		thrown = true;
		held = false;
		transform.parent = null;
	}
	public virtual void FunctionAlpha()
	{

	}
	public virtual void FunctionBeta()
	{
		
	}

}
	

