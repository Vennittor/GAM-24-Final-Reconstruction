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
	void Update () 
	{
		
	}

	// Plays the input animation for the input number of seconds.
	// animName is the name of the animation to be played.
	// time is the length in seconds you want to to finish by. If time = 0, playspeed will be set to normal (1).
	public void playTime(string a, float time = 0)
	{
		if (anim[a] != null)
		{
			if(anim.Play (a))
			{
				if(time > 0)
					anim [a].speed = anim [a].length / time;
				else
					anim [a].speed = 1;
			}
		}
	}

    // Stops all animation
    public void stop()
	{
		anim.Stop ();
	}

	public void playLoop(string a)
	{
		if (anim[a] != null)
		{
			if(!anim.IsPlaying(a))
				anim.Play (a);
		}
	}
}