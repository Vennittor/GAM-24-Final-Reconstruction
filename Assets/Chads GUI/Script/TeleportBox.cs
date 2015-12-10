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

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<BaseCharacter>())
		{
			other.GetComponent<BaseCharacter>().lives --;
			other.GetComponent<BaseCharacter>().health = 0;
			//other.GetComponent<TempPlayerController>().isDead = true;
			if (other.GetComponent<BaseCharacter>().lives > 0)
			{
                Debug.Log("respawn");
                deathSpawnPoint.GetComponent<Collider>().enabled = true;
                other.transform.position = deathSpawnPoint.transform.position + Vector3.up;
                other.transform.parent = deathSpawnPoint.transform;
                other.GetComponent<BaseCharacter>().Respawn(true);
                StartCoroutine(Lower(other.gameObject));
            }
			else
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
    IEnumerator Lower(GameObject other)
    {
        deathSpawnPoint.GetComponent<Collider>().enabled = true;
        SkinnedMeshRenderer[] components = deathSpawnPoint.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer component in components)
        {
            component.enabled = true;
        }
        while (deathSpawnPoint.transform.position.y >= 2)
        {
            deathSpawnPoint.transform.localPosition = Vector3.Lerp(deathSpawnPoint.transform.position,
                new Vector3(0, 1, 0), 1);
            if(deathSpawnPoint.transform.position.y <= 4)
                other.GetComponent<BaseCharacter>().Respawn(false);
            yield return null;
        }
        StartCoroutine(Higher());
        
    }
    IEnumerator Higher()
    {
        SkinnedMeshRenderer[] components = deathSpawnPoint.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer component in components)
        {
            component.enabled = false;
        }
        deathSpawnPoint.GetComponent<Collider>().enabled = false;
        while (deathSpawnPoint.transform.localPosition.y <= 8)
        {
            deathSpawnPoint.transform.localPosition = Vector3.Lerp(deathSpawnPoint.transform.position,
                new Vector3(0, 11, 0), 1);
            yield return null;
        }
    }

}
