using UnityEngine;
using System.Collections;

public class TeleportBox : MonoBehaviour 
{
	public GameObject deathSpawnPoint;
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerThree;
	public GameObject playerFour;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "PlayerOne")
		{
			other.GetComponent<TempPlayerController>().lives --;
			other.GetComponent<TempPlayerController>().health = 0;
			other.GetComponent<TempPlayerController>().isDead = true;
			if (other.GetComponent<TempPlayerController>().lives > 0)
			{
				other.transform.position = deathSpawnPoint.transform.position;
			}
			else
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
		if (other.gameObject.name == "PlayerTwo")
		{
			other.GetComponent<TempPlayerController>().lives --;
			other.GetComponent<TempPlayerController>().health = 0;
			other.GetComponent<TempPlayerController>().isDead = true;
			if (other.GetComponent<TempPlayerController>().lives > 0)
			{
				other.transform.position = deathSpawnPoint.transform.position;
			}
			else
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
		if (other.gameObject.name == "PlayerThree")
		{
			other.GetComponent<TempPlayerController>().lives --;
			other.GetComponent<TempPlayerController>().health = 0;
			other.GetComponent<TempPlayerController>().isDead = true;
			if (other.GetComponent<TempPlayerController>().lives > 0)
			{
				other.transform.position = deathSpawnPoint.transform.position;
			}
			else
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
		if (other.gameObject.name == "PlayerFour")
		{
			other.GetComponent<TempPlayerController>().lives --;
			other.GetComponent<TempPlayerController>().health = 0;
			other.GetComponent<TempPlayerController>().isDead = true;
			if (other.GetComponent<TempPlayerController>().lives > 0)
			{
				other.transform.position = deathSpawnPoint.transform.position;
			}
			else
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
}
