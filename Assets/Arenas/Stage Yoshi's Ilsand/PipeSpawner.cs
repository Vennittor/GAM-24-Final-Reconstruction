using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour 
{
	public GameObject prefab = null;
	public float spawnDelay = 10.0f;
	public float timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = timer + Time.deltaTime;
		if (timer>= spawnDelay)
		{
			Instantiate(prefab, this.gameObject.transform.position, gameObject.transform.rotation);
			timer = 0.0f;
		}
			
	}
}
