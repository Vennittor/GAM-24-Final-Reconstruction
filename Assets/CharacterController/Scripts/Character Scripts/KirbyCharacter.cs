using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KirbyCharacter : BaseCharacter 
{
	public bool hasEaten;
	public GameObject eatenPlayer;
	public override void Awake () 
	{
		playerStates = this.gameObject.GetComponent<PlayerStates> ();
		disabledStates = this.gameObject.GetComponent<DisabledStates> ();
		inputManager = this.gameObject.GetComponent<CharacterInputManager> ();
		rigidBody = this.gameObject.GetComponent<Rigidbody> ();
		Physics.IgnoreCollision (this.gameObject.GetComponent<Collider> (), hitCollider.GetComponent<Collider> ());
		hitCollider.SetActive (false);
		hitCollider.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		weight = 1f;
		speed = 20.0f;
		health = 0;
		jumpHeight = 10f;
		jumpMax = 5;
		attackCount = 0;
		hasEaten = false;
		eatenPlayer = null;

		//bool hasItem;
	}

	public override void StandingA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.1f;
			Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3 (1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
		// Neutral Standing A Animation
		// Neutral Standing A Sound 
	}
	public override void ComboA()
	{
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
				float attackLegnth = 10f;
				Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
				Vector3 position = new Vector3 (1f, 0f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = false;
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
		float attackLegnth = 0.15f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (0.5f, 1f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.back;
		float rotationSpeed = 500.0f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
	}
	public override void LeftRightA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.15f;
			Vector3 boxCollider = new Vector3 (1.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3 (1f, 0f, 0.5f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 500.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
	}
	public override void DownA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.15f;
			Vector3 boxCollider = new Vector3 (1.5f, 0.5f, 0.5f);
			Vector3 position = new Vector3 (1f, -0.3f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 500.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
	}
	public override void UpA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.25f;
			Vector3 boxCollider = new Vector3 (3.0f, 0.4f, 0.1f);
			Vector3 position = new Vector3 (-1.0f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1200.0f;
			
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
	}
	public override void SprintA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float temp = 0;
			if (transform.rotation == Quaternion.Euler(new Vector3 (0f, 180f, 0f)))
				temp = -100f;
			else if (transform.rotation == Quaternion.identity)
				temp = 100f;
			
			float attackLegnth = 0.7f;
			Vector3 boxCollider = new Vector3 (3f, 1f, 0.2f);
			Vector3 position = new Vector3 (0f, 1f, 0f);
			Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
			float lerpSpeed = 1.0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1500.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
		// Kirby Dashing A Animation
		// Kirby Dashing A Sound
	}
	public override void NeutralAAir()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.5f;
			Vector3 boxCollider = new Vector3 (3.0f, 3.0f, 0.2f);
			Vector3 position = Vector3.zero;
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1250.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}

		// Neutral A Air Animation
		// Neutral A Air Sound 
	}
	public override void UpAir()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.2f;
			Vector3 boxCollider = new Vector3 (3.0f, 0.4f, 0.1f);
			Vector3 position = new Vector3 (1.0f, -0.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1200.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
		// Up Air Animation
		// Up Air Sound
	}
	public override void DownAir()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.4f;
			Vector3 boxCollider = new Vector3 (1.5f, 0.4f, 0.1f);
			Vector3 position = new Vector3 (1.2f, -1.1f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1200.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
		// Down Air Animation
		// Down Air Sound
	}
	public override void LeftRightAir()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.4f;
			Vector3 boxCollider = new Vector3 (1.5f, 0.4f, 0.1f);
			Vector3 position = new Vector3 (1f, -0.2f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.up;
			float rotationSpeed = 1200.0f;
			
			StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}

		// Left Air Animation
		// Left Air Sound
	}
	public override void UpSmashA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.2f;
			Vector3 boxCollider = new Vector3 (3.0f, 0.4f, 0.1f);
			Vector3 position = new Vector3 (1.0f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = true;
			Vector3 rotationDirection = Vector3.forward;
			float rotationSpeed = 1200.0f;
			
			if (!started)
			{
				smashTime = new Timer (1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => {started = false;};
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
	}
	public override void DownSmashA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.6f;
			Vector3 boxCollider = new Vector3 (3.5f, 0.8f, 0.1f);
			Vector3 position = new Vector3 (0f, -0.5f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.down;
			float rotationSpeed = 1200.0f;
			
			if (!started)
			{
				smashTime = new Timer (1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => {started = false;};
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
	}
	public override void LeftRightSmashA()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float temp = 0;
			if (transform.rotation == Quaternion.Euler(new Vector3 (0f, 180f, 0f)))
				temp = -15f;
			else if (transform.rotation == Quaternion.identity)
				temp = 15f;
			
			float attackLegnth = 0.2f;
			Vector3 boxCollider = new Vector3 (1.5f, 0.8f, 0.1f);
			Vector3 position = new Vector3 (1f, 0f, 0f);
			Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
			float lerpSpeed = 1000f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0f;
			
			if (!started)
			{
				smashTime = new Timer (1.2f);
				started = true;
				StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
				                           pivot, rotationDirection, rotationSpeed));
			}
			smashTime.timerComplete += () => {started = false;};
		}
		else
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (1200f, 0f, 0f));
			eatenPlayer = null;
		}
		// Left A Smash Animarion 
		// Left A Smash Sound 
	}
	public override void NeutralB()
	{
		if (eatenPlayer == null)
		{
			float attackLegnth = 100f;
			Vector3 boxCollider = new Vector3 (5f, 5f, 0.5f);
			Vector3 position = new Vector3 (1f, 0f, 0f);
			Vector3 lerpVelocity = Vector3.zero;
			float lerpSpeed = 0f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			bool buttonHold = true;
			bool neutralB = true;

			StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {}, neutralB));
		}
		else if (!hasEaten)
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			hasEaten = true;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
		}
		else
			eatenPlayer.GetComponent<BaseCharacter>().NeutralB();

		// Neutral B Animation
		// Neutral B Sound
	}
	public override void UpSpecialB()
	{
		if (eatenPlayer == null && !hasEaten || eatenPlayer != null && hasEaten)
		{
			float attackLegnth = 0.3f;
			Vector3 boxCollider = new Vector3 (3f, 1f, 0.5f);
			Vector3 position = new Vector3 (1f, 0f, 0f);
			Vector3 lerpVelocity = new Vector3(0f, 50f, 0f);
			float lerpSpeed = 100f;
			bool pivot = false;
			Vector3 rotationDirection = Vector3.zero;
			float rotationSpeed = 0.0f;
			bool buttonHold = false;
			bool neutralB = false;

			StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {UpBEnd();}, neutralB));
		}
		else if (!hasEaten)
		{
			eatenPlayer.GetComponent<PlayerStates>().disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			eatenPlayer.transform.localScale = new Vector3 (1f, 1f, 1f);
			eatenPlayer.transform.parent = null;
			hasEaten = true;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.isKinematic = false;
			eatenPlayer.GetComponent<BaseCharacter>().rigidBody.AddForce(new Vector3 (0, 2100f, 0f));
		}
		// Up B Special Animarion 
		// Up B Special Sound 
	}
	private void UpBEnd()
	{
		float attackLegnth = 100f;
		Vector3 boxCollider = new Vector3 (3f, 1f, 0.5f);
		Vector3 position = new Vector3 (1f, 0f, 0f);
		Vector3 lerpVelocity = new Vector3(0f, -50f, 0f);
		float lerpSpeed = 100f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		bool buttonHold = false;
		bool neutralB = false;

		StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {}, neutralB));
	}

	public override void DownSpecialB()
	{
		float attackLegnth = 0.5f;
		Vector3 boxCollider = new Vector3 (2.0f, 1.5f, 0.2f);
		Vector3 position = new Vector3 (1.0f, 0f, 0.3f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.up;
		float rotationSpeed = 550.0f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		// Down B Special Animarion 
		// Down B Special Sound 
	}
	public override void LeftRightSpecialB()
	{
		float attackLegnth = 0.5f;
		Vector3 boxCollider = new Vector3 (2.0f, 1.5f, 0.2f);
		Vector3 position = new Vector3 (1.0f, 0f, 0.3f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.up;
		float rotationSpeed = 550.0f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		// Left B Special Animarion 
		// Left B Special Sound 
	}
	public override void AGrab()
	{
		print ("Kirby A Grab was called");
		// A Grab Animation
		// A Grab Sound
	}
	public override void UpThrow()
	{
		print ("Kirby Up Throw was called");
		// Up Throw Animation
		// Up Throw Sound 
	}
	public override void DownThrow()
	{
		print ("Kirby Down Throw was called");
		// Down Throw Animation
		// Down Throw Sound 
	}
	public override void LeftRightThrow()
	{
		print ("Kirby LeftRight Throw was called");
		// Left Throw Animation
		// Left Throw Sound 
	}
	public override void LedgeAttack()
	{
		print ("Kirby Ledge Attack was called");
		// Ledge Attack Animation
		// Ledge Attack Sound
	}
	
	public override IEnumerator AttackMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                  bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
		hitCollider.SetActive (true);

		while (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
		{
			disabledStates.vAttackLength = attackLength;

			hitCollider.transform.localPosition = position;
			hitCollider.transform.localScale = boxCollider;

			rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);

			if (pivot)
				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			else
				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);

			yield return null;
		}
	}

	public override void ResetAttack()
	{
		if (disabledStates.lockTime != null)
			disabledStates.lockTime.Kill ();

		hitCollider.GetComponent<HitCollider> ().otherPlayer = null;
		hitCollider.GetComponent<HitCollider> ().hitPlayer = false;
		hitCollider.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		hitCollider.transform.localPosition = Vector3.zero;
		hitCollider.SetActive (false);
		hitCollider.transform.localRotation = Quaternion.identity;

		smashBar.GetComponentInParent<Canvas> ().transform.localPosition = new Vector3 (300f, 300f, 300f);

		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
			playerStates.disabledStates.Remove (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
		
		if (parent != null)
		{
			parent.transform.localPosition = Vector3.zero;
			parent.transform.localRotation = Quaternion.identity;
		}
	}

	public override IEnumerator ComboAttack (float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
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
	}

	public override IEnumerator SmashAttack (float attackLegnth, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed,
	                                         bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		smashBar.GetComponentInParent<Canvas> ().transform.localPosition = new Vector3 (0f, 2f, 0f);
		while(Input.GetButton(inputManager.playerName + "_Attack") && started)
		{
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;

			yield return null;
		}

		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;

		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
		smashTime.Kill ();
	}

	private IEnumerator SpecialMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                           bool pivot, Vector3 rotationDirection, float rotationSpeed, bool buttonHold, System.Action end, bool neutralB)
	{
		hitCollider.SetActive (true);

		playerStates.disabledStates.Add (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);

		bool input;
		if (buttonHold)
			input = Input.GetButton (inputManager.playerName + "_Special");
		else
			input = playerStates.disabledStates.Contains (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);

		while (input)
		{
			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;

			if (buttonHold)
				input = Input.GetButton (inputManager.playerName + "_Special");
			else
				input = playerStates.disabledStates.Contains (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);

			disabledStates.vAttackLength = attackLength;
			
			hitCollider.transform.localPosition = position;
			hitCollider.transform.localScale = boxCollider;
			
			rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
			
			if (pivot)
				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
			else
				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);

			if (hitCollider.GetComponent<HitCollider> ().otherPlayer != null && neutralB)
			{
				eatenPlayer = hitCollider.GetComponent<HitCollider> ().otherPlayer;
				eatenPlayer.GetComponent<PlayerStates>().disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);

				eatenPlayer.transform.position = Vector3.Lerp(eatenPlayer.transform.position, this.transform.position, 10f * Time.deltaTime);
				if (Vector3.Distance(eatenPlayer.transform.position, this.transform.position) < 0.2f)
				{
					eatenPlayer.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
					eatenPlayer.transform.position = this.transform.position;
					eatenPlayer.transform.SetParent(this.transform);
					eatenPlayer.GetComponent<Rigidbody>().isKinematic = true;
				}
			}

			yield return null;
		}
		ResetAttack ();
		if (end != null)
			end ();

	}
}



















