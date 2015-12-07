using UnityEngine;
using System.Collections;

public class PipePair : MonoBehaviour 
{
	public float speed = 1.0f;

	public Vector3 startPosition = new Vector3(0,0,0);
	public int travelDistance = 100;

	// Use this for initialization
	void Start () 
	{
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

		float distance = Vector3.Distance(startPosition, transform.position);

		if (distance > travelDistance)
			transform.position = startPosition;

	}
}
