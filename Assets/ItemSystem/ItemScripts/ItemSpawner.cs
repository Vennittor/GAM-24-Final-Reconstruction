using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemSpawner : MonoBehaviour 
{
	public float mapLength;
	public float spawnRate = 3.0f;

	bool moveRight = true;

	ItemSelector selector;



	public List<GameObject> itemsAwake = new List<GameObject>();
	// Use this for initialization
	void Awake () 
	{
		selector = GetComponent<ItemSelector> ();
		InvokeRepeating ("SpawnChance", spawnRate, spawnRate);
	}
	
	// Update is called once per frame
	void Update () 
	{
	if (moveRight) 
		{
			if (gameObject.transform.position.x <= mapLength) 
			{
				transform.position +=new Vector3(1,0,0) * Time.deltaTime;
			}
			else
				moveRight = false;
		}
		else
		{
			if (gameObject.transform.position.x >= mapLength * -1) 
			{
				transform.position -=new Vector3(1,0,0) * Time.deltaTime;
			}
			else
				moveRight = true;
		}
	}
	void SpawnChance()
	{
		if (GetComponent<ItemSpawner>().itemsAwake.Count <= 10) 
		{
			float randomChance = Random.Range (0, 100);
			if (randomChance < 20) 
			{
				GameObject a = Instantiate(selector.SpawnItem(selector.RandomDrop ()),
				                           transform.position,
				                           Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
				itemsAwake.Add(a);
			}
		}
	}

}
