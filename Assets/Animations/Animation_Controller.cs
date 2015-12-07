using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour {

	public Animation anim;

	void Awake() {
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
}
