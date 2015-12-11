using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{
	        if (other.gameObject.GetComponent<BaseCharacter>())
	        {
	            other.gameObject.GetComponent<BaseCharacter>().lives--;
	            other.gameObject.GetComponent<BaseCharacter>().health = 0;
	            GameObject sceneCam = GameObject.Find("SceneCamera");
	            sceneCam.GetComponent<SceneCamera>().players.Remove(other.gameObject);
	            if (other.gameObject.GetComponent<BaseCharacter>().lives > 0)
	            {
	                Debug.Log("respawn");
	                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
	                other.transform.position = deathSpawnPoint.transform.position;
	                other.GetComponent<BaseCharacter>().Respawn(true);
	                
	                sceneCam.GetComponent<SceneCamera>().players.Add(other.gameObject);
	            }
	            else
	            {
	                other.gameObject.GetComponent<DisabledStates>().LockAll();
	                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
	            }
	        }
		}
    }
}
