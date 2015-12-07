using UnityEngine;
using System.Collections;

public class CloudGuy : MonoBehaviour 
{
	public float speed = 3.0f;

	public Vector3 rightLimit = new Vector3(65,7.7f,0);

	public Vector3 leftLimit =  new Vector3(33,7.7f,0);
	public bool moveRight = true;

	void Start () 
	{
		transform.position = rightLimit;
	}
	

	void Update () 
	{
		if(moveRight)
		{
			gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

			if(transform.position.x > rightLimit.x)
				moveRight = false;
		}
		else
		{
			gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);

			if(transform.position.x < leftLimit.x)
				moveRight = true;
		}
	}
}
