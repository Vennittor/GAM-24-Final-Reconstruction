using UnityEngine;
using System.Collections;

public class SamusCharacter : BaseCharacter 
{

	// Use this for initialization
	public override void Awake () 
	{
		rigidBody = this.gameObject.GetComponent<Rigidbody> ();
		
		weight = 4f;
		speed = 17.0f;
		health = 0;
		jumpHeight = 8f;
		jumpMax = 2;
		attackCount = 0;
		frozen = false;
		if (model == null)
		{
			model = Instantiate(Resources.Load("Kirby_2"), gameObject.transform.position - new Vector3(0,0.5f,0),Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
			model.transform.parent = gameObject.transform;
			animControl = model.GetComponent<Animation_Controller>(); 
		}
		base.Awake();
		//bool hasItem;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public override void StandingA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 0.3f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, 1f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 20.0f;
			
			int damage = 5;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
	}
	
	public override void ComboA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (!started)
		{
			attackCount = 0;
			comboTime = new Timer (0.5f);
			started = true;
		}
		else
		{
			attackCount++;
			if (attackCount >= 2)
			{
				comboTime.Pause();
				float attackLegnth = 5f;
				Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
				Vector3 position = new Vector3 (.5f, 0f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = true;
				Vector3 rotationDirection = Vector3.back;
				float rotationSpeed = 10.0f;
				
				StartCoroutine (ComboAttack (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			else
				StandingA();
		}
		comboTime.timerComplete += () => {started = false; if (attackCount >=2) comboEnd (); attackCount = 0; };
	}
	public void comboEnd()
	{
		float attackLegnth = 0.15f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (0.5f, 1f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.back;
		float rotationSpeed = 500.0f;
		
		int damage = 10;
		float knockBack = 6.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                                knockBack, state, stateDuration));
	}
	public void DashingA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 2f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 500.0f;
			
			int damage = 5;
			float knockBack = 8.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Dashing A Animation
		// Dashing A Sound
	}
	public void NeutralStandingA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 0.1f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Neutral Standing A Animation
		// Neutral Standing A Sound 
	}
	public void NeutralAAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 2f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = new Vector3(0,1,0);
			float rotationSpeed = 400.0f;
			
			int damage = 10;
			float knockBack = 10.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Neutral A Air Animation
		// Neutral A Air Sound 
	}
	public void UpAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 1f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.left;
			float rotationSpeed = 300.0f;
			
			int damage = 8;
			float knockBack = 8.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Up Air Animation
		// Up Air Sound
	}
	public void DownAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 0.5f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, -.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 300.0f;
			
			int damage = 11;
			float knockBack = 11.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Down Air Animation
		// Down Air Sound
	}
	public void LeftRightAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 0.1f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Left Air Animation
		// Left Air Sound
	}
	public void RightAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 1f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(.5f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 300.0f;
			
			int damage = 12;
			float knockBack = 12.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Right Air Animation
		// Right Air Sound
	}
	public void UpSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			attackCount++;
			if (attackCount >= 3)
			{
				comboTime.Pause();
				float attackLegnth = 5f;
				Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
				Vector3 position = new Vector3 (.5f, 1f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = true;
				Vector3 rotationDirection = Vector3.back;
				float rotationSpeed = 10.0f;
				
				StartCoroutine (ComboAttack (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			else
				UpA();
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Up A Smash Animarion 
		// Up A Smash Sound 
	}
	public void DownSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 0.3f;
			Vector3 boxCollider = new Vector3(2f, 0.1f, .1f);
			Vector3 position = new Vector3(0f, -1f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 0.0f;
			
			int damage = 8;
			float knockBack = 5.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Down A Smash Animarion 
		// Down A Smash Sound 
	}
	public void LeftRightSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
		}
		else
		{
			float attackLegnth = 2f;
			Vector3 boxCollider = new Vector3(0.5f, 1f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 500.0f;
			
			int damage = 22;
			float knockBack = 22f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Left A Smash Animarion 
		// Left A Smash Sound 
	}
}
