using UnityEngine;
using System.Collections;

public class LinkCharacter : BaseCharacter 
{
	// Use this for initialization
	public override void Awake () 
	{
		weight = 1.0f;
		rigidBody = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void DashingA()
	{
		print ("Link Dashing A was called ");
		// Dashing A Animation
		// Dashing A Sound
	}
	public void NeutralStandingA()
	{
		print ("Link Neutral Standing A Attack was called");
		// Neutral Standing A Animation
		// Neutral Standing A Sound 
	}
	public void NeutralAAir()
	{
		print ("Link Neutral A Air was called");
		// Neutral A Air Animation
		// Neutral A Air Sound 
	}
	public void UpAir()
	{
		print ("Link Up Air was called");
		// Up Air Animation
		// Up Air Sound
	}
	public void DownAir()
	{
		print ("Link Down Air was called");
		// Down Air Animation
		// Down Air Sound
	}
	public void LeftRightAir()
	{
		print ("Link Left Air was called");
		// Left Air Animation
		// Left Air Sound
	}
	public void RightAir()
	{
		print ("Link Right Air was called");
		// Right Air Animation
		// Right Air Sound
	}
	public void UpSmashA()
	{
		print ("Link Smash A Up was called");
		// Up A Smash Animarion 
		// Up A Smash Sound 
	}
	public void DownSmashA()
	{
		print ("Link Smash A Down was called");
		// Down A Smash Animarion 
		// Down A Smash Sound 
	}
	public void LeftRightSmashA()
	{
		print ("Link Smash A LeftRight was called");
		// Left A Smash Animarion 
		// Left A Smash Sound 
	}
	public override void NeutralB()
	{
		print ("Link Neutral B was called");
		// Neutral B Animation
		// Neutral B Sound
	}
	public void UpSpecialB()
	{
		print ("Link Special B Up was called");
		// Up B Special Animarion 
		// Up B Special Sound 
	}
	public void DownSpecialB()
	{
		print ("Link Special B Down was called");
		// Down B Special Animarion 
		// Down B Special Sound 
	}
	public void LeftRightSpecialB()
	{
		print ("Link Special B LeftRight was called");
		// Left B Special Animarion 
		// Left B Special Sound 
	}
	public void AGrab()
	{
		print ("Link A Grab was called");
		// A Grab Animation
		// A Grab Sound
	}
	public void UpThrow()
	{
		print ("Link Up Throw was called");
		// Up Throw Animation
		// Up Throw Sound 
	}
	public void DownThrow()
	{
		print ("Link Down Throw was called");
		// Down Throw Animation
		// Down Throw Sound 
	}
	public void LeftRightThrow()
	{
		print ("Link LeftRight Throw was called");
		// Left Throw Animation
		// Left Throw Sound 
	}
	public void LedgeAttack()
	{
		print ("Link Ledge Attack was called");
		// Ledge Attack Animation
		// Ledge Attack Sound
	}
	public void FinalSmash()
	{
		print ("Link Final Smash was called");
		// Final Smash Animation
		// Final Smash Sound
	}
	
}
