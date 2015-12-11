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
        if (other.gameObject.GetComponent<BaseCharacter>())
        {
            other.GetComponent<BaseCharacter>().lives--;
            other.GetComponent<BaseCharacter>().health = 0;
            GameObject sceneCam = GameObject.Find("SceneCamera");
            sceneCam.GetComponent<SceneCamera>().players.Remove(other.gameObject);
            if (other.GetComponent<BaseCharacter>().lives > 0)
            {
                Debug.Log("respawn");
                deathSpawnPoint.GetComponent<Collider>().enabled = true;
                other.transform.position = deathSpawnPoint.transform.position + Vector3.up;
                other.GetComponent<BaseCharacter>().Respawn(true,sceneCam);
            }
            else
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
