using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour {

	public Animation anim;

	void Awake() 
	{
		anim = gameObject.transform.GetComponent<Animation>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Plays the input animation for the input number of seconds.
	// animName is the name of the animation to be played.
	// time is the length in seconds you want to to finish by.
	public void playAnim(string a, float time)
	{
		anim [a].speed = anim [a].length / time;
		anim.Play (a);	
	}

	// Stops all animation
	public void stop()
	{
		anim.Stop ();
	}

	public void idle()
	{
		if(!anim.IsPlaying("Idle"))
			anim.Play ("Idle");
	}
	

	#region ApplyForce example
	//These are placeholder variables and need to be properly referenced in the script.
	Vector3 position;	//of the hitCollider
	GameObject other;

	public void ApplyForce(float force)
	{

		Vector3 forceDir = position - this.gameObject.transform.position;
		forceDir *= force;

		_ApplyForce(forceDir, ForceMode.Force);
	}
	
	public void ApplyForce(float force, ForceMode forcemode)
	{
		Vector3 forceDir = position - this.gameObject.transform.position;
		forceDir *= force;
		
		_ApplyForce(forceDir, forcemode);
	}

	public void ApplyForce(Vector3 forceDir)
	{
		_ApplyForce(forceDir, ForceMode.Force);
	}

	public void ApplyForce(Vector3 forceDir, ForceMode forcemode)
	{
		_ApplyForce(forceDir, forcemode);
	}

	public void _ApplyForce(Vector3 force, ForceMode forcemode)
	{
		//Establish proper reference to the other characters rigidbody. 
		other.gameObject.GetComponent<Rigidbody>().AddForce (force, forcemode);
	}
	#endregion
}
