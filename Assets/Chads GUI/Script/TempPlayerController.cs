using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempPlayerController : MonoBehaviour 
{
	public int lives = 2;

	public float health;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health > 999) 
		{
			health = 999;
		}
	}
}
