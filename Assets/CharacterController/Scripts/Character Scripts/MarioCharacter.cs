using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarioCharacter : BaseCharacter 
{
	// Use this for initialization
	public override void Awake() 
	{
		weight = 1.5f;
		speed = 20.0f;
		health = 0;
		jumpHeight = 10f;
		jumpMax = 1;
		attackCount = 3;
		frozen = false;
		if (model == null)
		{
			model = Instantiate(Resources.Load("Mario_1"), gameObject.transform.position - new Vector3(0,0.5f,0),Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
			model.transform.parent = gameObject.transform;
			animControl = model.GetComponent<Animation_Controller>(); 
		}
		base.Awake();
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
			Vector3 position = new Vector3(1f, 0f, 0f);
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
			
			// Neutral Standing A Animation
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
				float attackLegnth = 0.2f;
				Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
				Vector3 position = new Vector3 (1f, 0f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = false;
				Vector3 rotationDirection = Vector3.forward;
				float rotationSpeed = 0f;
				
				StartCoroutine (ComboAttack (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
			}
			else
				StandingA();
		}
		comboTime.timerComplete += () => {started = false; if (attackCount >=2) comboEnd (); attackCount = 0; };
	}
	public void comboEnd()
	{
		float attackLegnth = 0.2f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (0.5f, -1f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.forward;
		float rotationSpeed = 500.0f;
		
		int damage = 5;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                                knockBack, state, stateDuration));
	}
	public override void LeftRightA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 1f;
			Vector3 boxCollider = new Vector3 (1f, 0.5f, 0.5f);
			Vector3 position = new Vector3 (1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			int damage = 5;
			float knockBack = 0.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                                knockBack, state, stateDuration));
		}
	}
	public override void DownA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.down);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.5f;
			Vector3 boxCollider = new Vector3(.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(1f, -0.3f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 300.0f;
			
			int damage = 6;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
		}
	}
	public override void UpA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.25f;
			Vector3 boxCollider = new Vector3(.5f, .5f, 0.5f);
			Vector3 position = new Vector3(-0.1f, -1f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1000.0f;
			
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
			
			int damage = 4;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
		}
	}
	public override void SprintA()
	{
		if (playerStates.disabledStates.Contains (PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem) 
		{
			if (GetComponentInChildren<ItemBaseScript> ())
				GetComponentInChildren<ItemBaseScript> ().FunctionAlpha (Vector3.up);
			else
				hasItem = false;
		}
		else 
		{
			float temp = 0;
			if (transform.rotation == Quaternion.Euler(new Vector3(0f, 180f, 0f)))
				temp = -10f;
			else if (transform.rotation == Quaternion.identity)
				temp = 10f;

			float attackLegnth = 0.25f;
			Vector3 boxCollider = new Vector3 (1f, 1f, 0.5f);
			Vector3 position = new Vector3 (1f, -0.5f, 0f);
			Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
			float lerpSpeed = 1f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
			
			int damage = 4;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                                knockBack, state, stateDuration));
		}
	}
	
	
	public override void NeutralAAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.5f;
			Vector3 boxCollider = new Vector3(0.5f,0.5f,0.5f);
			Vector3 position = new Vector3 (1.0f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 0.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Neutral A Air Animation
			// Neutral A Air Sound
		} 
	}
	public override void UpAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.5f;
			Vector3 boxCollider = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3(0f, -1.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.back;
			float rotationSpeed = 1200.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			// Down Air Animation
			// Down Air Sound
		}
	}
	public override void DownAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.6f;
			Vector3 boxCollider = new Vector3(2f, 2.1f, 0.5f);
			Vector3 position = Vector3.zero;
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1000.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			// Up Air Animation
			// Up Air Sound
		}
	}
	public override void LeftRightAir()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.4f;
			Vector3 boxCollider = new Vector3(1.5f, 0.4f, 0.1f);
			Vector3 position = new Vector3(1f, -0.2f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1200.0f;
			
			int damage = 3;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;
			
			StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
			                              knockBack, state, stateDuration));
			
			// Left Air Animation
			// Left Air Sound
		}
	}
	public override void UpSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.25f;
			Vector3 boxCollider = new Vector3(.5f, .5f, 0.5f);
			Vector3 position = new Vector3(-0.1f, -1f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1000.0f;
			
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
			
			int damage = 4;
			float knockBack = 1.0f;
			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
			float stateDuration = 0.5f;

			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };
		}
	}
	public override void DownSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.down);
			else
				hasItem = false;
		}
		else
		{
			float attackLegnth = 0.3f;
			Vector3 boxCollider = new Vector3(3f, 1f, 0.5f);
			Vector3 position = new Vector3(0f, -0.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.down;
			float rotationSpeed = 1200.0f;
			
			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };
		}
	}
	public override void LeftRightSmashA()
	{
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		else
		{
			float temp = 0;
			if (transform.rotation == Quaternion.Euler(new Vector3(0f, 180f, 0f)))
				temp = -15f;
			else if (transform.rotation == Quaternion.identity)
				temp = 15f;
			
			float attackLegnth = 0.2f;
			Vector3 boxCollider = new Vector3(1.5f, 0.8f, 0.1f);
			Vector3 position = new Vector3(1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0f;
			
			if (!started)
			{
				smashTime = new Timer(1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => { started = false; };
			// Left A Smash Animarion 
			// Left A Smash Sound 
		}
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
	//	public override void NeutralB()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		if (eatenPlayer == null)
	//		{
	//			if (!rock)
	//			{
	//				float attackLegnth = 100f;
	//				Vector3 boxCollider = new Vector3 (5f, 5f, 0.5f);
	//				Vector3 position = new Vector3 (1f, 0f, 0f);
	//				Vector3 lerpVelocity = Vector3.zero;
	//				float lerpSpeed = 0f;
	//				bool pivot = false;
	//				Vector3 rotationDirection = Vector3.zero;
	//				float rotationSpeed = 0.0f;
	//				bool buttonHold = true;
	//				bool neutralB = true;
	//				
	//				StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {}, neutralB));
	//			}
	//			else
	//			{
	//				rigidBody.AddForce(new Vector3 (0f, 1500f, 0f));
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.NOKNOCKBACK);
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.FLINCHIMMUNE);
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.NODAMAGE);
	//				rock = false;
	//			}
	//		}
	//		else if (!hasEaten)
	//		{
	//			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
	//			eatenPlayer.transform.parent = null;
	//			hasEaten = true;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
	//		}
	//		else
	//			eatenPlayer.GetComponent<BaseCharacter>().NeutralB();
	//		
	//		// Neutral B Animation
	//		// Neutral B Sound
	//	}
	//	public override void UpSpecialB()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
	//		{
	//			float attackLegnth = 0.3f;
	//			Vector3 boxCollider = new Vector3 (3f, 1f, 0.5f);
	//			Vector3 position = new Vector3 (1f, 0f, 0f);
	//			Vector3 lerpVelocity = new Vector3(0f, 50f, 0f);
	//			float lerpSpeed = 100f;
	//			bool pivot = false;
	//			Vector3 rotationDirection = Vector3.zero;
	//			float rotationSpeed = 0.0f;
	//			bool buttonHold = false;
	//			bool neutralB = false;
	//			
	//			StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {UpBEnd();}, neutralB));
	//		}
	//		else if (!hasEaten)
	//		{
	//			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
	//			eatenPlayer.transform.parent = null;
	//			hasEaten = true;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
	//		}
	//		// Up B Special Animarion 
	//		// Up B Special Sound 
	//	}
	//	private void UpBEnd()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		float attackLegnth = 100f;
	//		Vector3 boxCollider = new Vector3 (3f, 1f, 0.5f);
	//		Vector3 position = new Vector3 (1f, 0f, 0f);
	//		Vector3 lerpVelocity = new Vector3(0f, -50f, 0f);
	//		float lerpSpeed = 100f;
	//		bool pivot = false;
	//		Vector3 rotationDirection = Vector3.zero;
	//		float rotationSpeed = 0.0f;
	//		bool buttonHold = false;
	//		bool neutralB = false;
	//		
	//		StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {}, neutralB));
	//	}
	//	public override void DownSpecialB()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
	//		{
	//			if (!rock)
	//			{
	//				this.GetComponent<MeshRenderer>().material.color = Color.yellow;
	//				float attackLegnth = 100f;
	//				Vector3 boxCollider = new Vector3 (1f, 1f, 1f);
	//				Vector3 position = Vector3.zero;
	//				Vector3 lerpVelocity = new Vector3(0f, -80f, 0f);
	//				float lerpSpeed = 100f;
	//				bool pivot = false;
	//				Vector3 rotationDirection = Vector3.zero;
	//				float rotationSpeed = 0f;
	//				rock = true;
	//				playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.NOKNOCKBACK);
	//				playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.FLINCHIMMUNE);
	//				playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.NODAMAGE);
	//				
	//				StartCoroutine (kirbyRock (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
	//			}
	//			else
	//			{
	//				rigidBody.AddForce(new Vector3 (0f, 1500f, 0f));
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.NOKNOCKBACK);
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.FLINCHIMMUNE);
	//				playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.NODAMAGE);
	//				rock = false;
	//			}
	//		}
	//		else if (!hasEaten)
	//		{
	//			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
	//			eatenPlayer.transform.parent = null;
	//			hasEaten = true;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
	//		}
	//		// Down B Special Animarion 
	//		// Down B Special Sound 
	//	}
	//	public override void LeftRightSpecialB()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
	//		{
	//			float attackLegnth = 0.5f;
	//			Vector3 boxCollider = new Vector3 (2.0f, 1.5f, 0.2f);
	//			Vector3 position = new Vector3 (1.0f, 0f, 0.3f);
	//			Vector3 lerpVelocity = Vector3.zero;
	//			float lerpSpeed = 0f;
	//			bool pivot = true;
	//			Vector3 rotationDirection = Vector3.up;
	//			float rotationSpeed = 550.0f;
	//			
	//			int damage = 10;
	//			float knockBack = 1.0f;
	//			PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
	//			float stateDuration = 0.5f;
	//			
	//			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
	//			                                knockBack, state, stateDuration));
	//		}
	//		else if (!hasEaten)
	//		{
	//			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
	//			eatenPlayer.transform.parent = null;
	//			hasEaten = true;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
	//			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
	//		}
	//		// Left B Special Animarion 
	//		// Left B Special Sound 
	//	}
	//	public override void AGrab()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		print ("Kirby A Grab was called");
	//		// A Grab Animation
	//		// A Grab Sound
	//	}
	//	public override void UpThrow()
	//	{
	//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
	//			return;
	//		print ("Kirby Up Throw was called");
	//		// Up Throw Animation
	//		// Up Throw Sound 
	//	}
	//	public override void DownThrow()
	//	{
	//		print ("Kirby Down Throw was called");
	//		// Down Throw Animation
	//		// Down Throw Sound 
	//	}
	//	public override void LeftRightThrow()
	//	{
	//		print ("Kirby LeftRight Throw was called");
	//		// Left Throw Animation
	//		// Left Throw Sound 
	//	}
	//	public override void LedgeAttack()
	//	{
	//		print ("Kirby Ledge Attack was called");
	//		// Ledge Attack Animation
	//		// Ledge Attack Sound
	//	}
	
	/*public override IEnumerator AttackMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                  bool pivot, Vector3 rotationDirection, float rotationSpeed, int damage, float knockBack, PlayerStates.disabledAndProtectiveStates state,
	                                           float stateDuration)
	{
        playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
        hitCollider.SetActive(true);

        while (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
        {
            disabledStates.vAttackLength = attackLength;

            hitCollider.transform.localPosition = position;
            hitCollider.transform.localScale = boxCollider;

            rigidBody.velocity = Vector3.Lerp(this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);

            if (pivot)
                parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
            else
                hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);

            hitCollider.GetComponent<HitCollider>().damage = damage;
            hitCollider.GetComponent<HitCollider>().knockBack = knockBack;
            hitCollider.GetComponent<HitCollider>().state = state;
            hitCollider.GetComponent<HitCollider>().stateDuration = stateDuration;

            yield return null;
        }
    }*/
	
	////public override void ResetAttack()
	////{
	////	if (!rock)
	////	{
	////		base.ResetAttack();
	////		/*
	//                if (disabledStates.lockTime != null)
	//				disabledStates.lockTime.Kill ();
	//
	//			hitCollider.GetComponent<HitCollider> ().otherPlayer = null;
	//			hitCollider.GetComponent<HitCollider> ().hitPlayer = false;
	//			hitCollider.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
	//			hitCollider.transform.localPosition = Vector3.zero;
	//			hitCollider.SetActive (false);
	//			hitCollider.transform.localRotation = Quaternion.identity;
	//
	//			smashBar.GetComponentInParent<Canvas> ().transform.localPosition = new Vector3 (300f, 300f, 300f);
	//
	//			if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
	//				playerStates.disabledStates.Remove (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			
	//			if (parent != null)
	//			{
	//				parent.transform.localPosition = Vector3.zero;
	//				parent.transform.localRotation = Quaternion.identity;
	//			}            
	//            */
	//	}
	//}
	
	//public override IEnumerator ComboAttack (float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, bool pivot, Vector3 rotationDirection, float rotationSpeed)
	//{
	/*
        hitCollider.SetActive (true);
		while (Input.GetButton(inputManager.playerName + "_Attack"))
		{
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;

			disabledStates.vAttackLength = attackLength;
			
			hitCollider.transform.localPosition = new Vector3 (1f, Random.Range(-1f, 1f), 0f);
			hitCollider.transform.localScale = boxCollider;
			
			rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
			
			if (pivot)
				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			else
				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			
			yield return null;
		}
		ResetAttack ();
		comboTime.Kill ();
        */
	// }
	
	/* public override IEnumerator SmashAttack (float attackLegnth, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed,
	                                         bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
        smashBar.GetComponentInParent<Canvas>().transform.localPosition = new Vector3(0f, 2f, 0f);
        while (Input.GetButton(inputManager.playerName + "_Attack") && started)
        {
            inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
            inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;

            yield return null;
        }

        inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
        inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;

        int damage = 3;
        float knockBack = 1.0f;
        PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
        float stateDuration = 0.5f;

        StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
                                        knockBack, state, stateDuration));
        smashTime.Kill();
    }*/
	
	//private IEnumerator SpecialMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	//                                    bool pivot, Vector3 rotationDirection, float rotationSpeed, bool buttonHold, System.Action end, bool neutralB)
	//{
	//	hitCollider.SetActive (true);
	//	
	//	playerStates.disabledStates.Add (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//	
	//	bool input;
	//	if (buttonHold)
	//		input = Input.GetButton (inputManager.playerName + "_Special");
	//	else
	//		input = playerStates.disabledStates.Contains (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//	
	//	while (input)
	//	{
	//		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
	//		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;
	//		
	//		if (buttonHold)
	//			input = Input.GetButton (inputManager.playerName + "_Special");
	//		else
	//			input = playerStates.disabledStates.Contains (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//		
	//		disabledStates.vAttackLength = attackLength;
	//		
	//		hitCollider.transform.localPosition = position;
	//		hitCollider.transform.localScale = boxCollider;
	//		
	//		rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
	//		
	//		if (pivot)
	//			parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
	//		else
	//			hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
	//		
	//		if (hitCollider.GetComponent<HitCollider> ().otherPlayer != null && neutralB)
	//		{
	//			eatenPlayer = hitCollider.GetComponent<HitCollider> ().otherPlayer;
	//			
	//			if (!eatenPlayer.GetComponent<PlayerStates>().disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
	//				eatenPlayer.GetComponent<PlayerStates>().disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
	//			
	//			eatenPlayer.transform.position = Vector3.Lerp(eatenPlayer.transform.position, this.transform.position, 10f * Time.deltaTime);
	//			if (Vector3.Distance(eatenPlayer.transform.position, this.transform.position) < 0.05f)
	//			{
	//				eatenPlayer.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
	//				eatenPlayer.transform.position = this.transform.position;
	//				eatenPlayer.transform.SetParent(this.transform);
	//				eatenPlayer.GetComponent<Rigidbody>().isKinematic = true;
	//			}
	//		}
	//		
	//		yield return null;
	//	}
	//	ResetAttack ();
	//	if (end != null)
	//		end ();
	//}
	//private IEnumerator kirbyRock(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	//                              bool pivot, Vector3 rotationDirection, float rotationSpeed)
	//{
	//	while(rock)
	//	{
	//		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
	//		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.spamButton = false;
	//		
	//		disabledStates.vAttackLength = attackLength;
	//		
	//		hitCollider.transform.localPosition = position;
	//		hitCollider.transform.localScale = boxCollider;
	//		
	//		rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
	//		
	//		if (pivot)
	//			parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
	//		else
	//			hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
	//		
	//		yield return null;
	//	}
	//}
}



















