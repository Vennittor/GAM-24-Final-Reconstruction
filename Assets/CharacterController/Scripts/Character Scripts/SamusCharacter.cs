using UnityEngine;
using System.Collections;

public class SamusCharacter : BaseCharacter 
{
	// Use this for initialization
	public override void Awake () 
	{
		rigidBody = this.gameObject.GetComponent<Rigidbody> ();
		
		weight = 1.3f;
		speed = 18.0f;
		health = 0;
		jumpHeight = 10f;
		jumpMax = 1;
		attackCount = 0;
		frozen = false;
		if (model == null)
		{
			model = Instantiate(Resources.Load("ZSSamus_1"), gameObject.transform.position - new Vector3(0,0.5f,0),Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
			model.transform.parent = gameObject.transform;
			animControl = model.GetComponent<Animation_Controller>(); 
		}
		base.Awake();
		//bool hasItem;
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
			float attackLegnth = 0.1f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1.0f, 0.8f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
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
				float attackLegnth = 0.1f;
				Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
				Vector3 position = new Vector3 (1f, 0f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = true;
				Vector3 rotationDirection = Vector3.zero;
				float rotationSpeed = 0.0f;
				
				StartCoroutine (ComboAttack (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			else
				StandingA();
		}
		comboTime.timerComplete += () => {started = false; if (attackCount >=2) comboEnd (); attackCount = 0; };
	}
	public void comboEnd()
	{
		float attackLegnth = 0.1f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1f, 0f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		
		int damage = 10;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                                knockBack, state, stateDuration));
	}

	public override void LeftRightA()
	{
		float attackLegnth = 0.4f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1f, 0.2f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.back;
		float rotationSpeed = 10.0f;
		
		int damage = 10;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                                knockBack, state, stateDuration));
	}

	public override void SprintA()
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
			float temp = 0;
			if (transform.rotation == Quaternion.Euler(new Vector3(0f, 180f, 0f)))
				temp = -50f;
			else if (transform.rotation == Quaternion.identity)
				temp = 50f;

			float attackLegnth = 0.6f;
			Vector3 boxCollider = new Vector3(2f, 1f, 1f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
			float lerpSpeed = 1f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 5;
			float knockBack = 1.0f;
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
	
	public override void NeutralAAir()
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
			Vector3 boxCollider = new Vector3(1f, 0.5f, 0.5f);
			Vector3 position = new Vector3(0.5f, -0.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.right;
			float rotationSpeed = 400.0f;
			
			int damage = 10;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 2f);
			
		}
		// Neutral A Air Animation
		// Neutral A Air Sound 
	}
	public override void UpAir()
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
			float attackLegnth = 0.2f;
			Vector3 boxCollider = new Vector3(1f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1200.0f;
			
			int damage = 8;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 1f);
			
		}
		// Up Air Animation
		// Up Air Sound
	}
	public override void DownAir()
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
			float attackLegnth = 5f;
			Vector3 boxCollider = new Vector3(1f, -1f, 0.5f);
			Vector3 position = new Vector3(0f, -1f, 0f);
			Vector3 lerpVelocity = new Vector3(0f, -100f, 0f);
			float lerpSpeed = 10f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 11;
			float knockBack = 0.2f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.5f);
			
		}
		// Down Air Animation
		// Down Air Sound
	}
	public override void LeftRightAir()
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
			Vector3 boxCollider = new Vector3(1f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 10;
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

	public override void UpSmashA()
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
			float attackLegnth = 1.0f;
			Vector3 boxCollider = new Vector3 (1.5f, 3f, 0.5f);
			Vector3 position = new Vector3 (0f, 2f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1000.0f;
			
			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Up A Smash Animarion 
		// Up A Smash Sound 
	}
	public override void DownSmashA()
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
			Vector3 boxCollider = new Vector3(2f, 1.0f, .1f);
			Vector3 position = new Vector3(1f, -0.9f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };
			
			StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Down A Smash Animarion 
		// Down A Smash Sound 
	}
	public override void LeftRightSmashA()
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
			float attackLegnth = 1.0f;
			Vector3 boxCollider = new Vector3(0.5f, 1f, 0.5f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 500.0f;
			
			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };
			
			StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			
			// Neutral Standing A Sound 
			animControl.playTime("Ground-Forward", 0.1f);
			
		}
		// Left A Smash Animarion 
		// Left A Smash Sound 
	}
	public IEnumerator ComboAttack(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                       bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		hitCollider.SetActive(true);
		while (Input.GetButton(inputManager.playerName + "_Attack"))
		{
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;
			
			disabledStates.vAttackLength = attackLength;
			
			hitCollider.transform.localPosition = position;
			hitCollider.transform.localScale = boxCollider;
			
			rigidBody.velocity = Vector3.Lerp(this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
			
			if (pivot)
				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			else
				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			
			yield return null;
		}
		ResetAttack();
		comboTime.Kill();
	}
}
