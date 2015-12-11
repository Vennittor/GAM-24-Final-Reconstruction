using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarioCharacter : BaseCharacter 
{
	public AudioClip[] audioClips;
	public override void Awake () 
	{
		weight = 1f;
		speed = 20.0f;
		health = 0;
		jumpHeight = 10f;
		jumpMax = 5;
		attackCount = 0;
		frozen = false;
		if (model == null)
		{
			model = Instantiate(Resources.Load("Mario_1"), gameObject.transform.position - new Vector3(0,0.5f,0.375f),Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
			model.transform.parent = gameObject.transform;
			animControl = model.GetComponent<Animation_Controller>(); 
		}
		audioClips = Resources.LoadAll<AudioClip>("Mario_Sounds");

		base.Awake();
		//bool hasItem;
	}
	
	void Update()
	{
//		if (Input.GetKeyDown(KeyCode.A))
//		{
//			UpAir();
//		}
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
		float attackLegnth = 0.1f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1f, 0.5f, 0f);
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
		
		// Neutral Standing A Animation
		// Neutral Standing A Sound 
		//animControl.playTime ("MarioCombo1", 0.2f);
		animControl.playTime ("MarioSuperPunch", 0.1f);
		AudioManager.instance.PlaySound(audioClips[4] as AudioClip);
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
				Vector3 position = new Vector3 (1f, 0.5f, 0f);
				Vector3 lerpVelocity = Vector3.zero;
				float lerpSpeed = 0f;
				bool pivot = false;
				Vector3 rotationDirection = Vector3.zero;
				float rotationSpeed = 0.0f;
				
				StartCoroutine (ComboAttack (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));

				animControl.playTime ("MarioCombo2", 0.1f);
				AudioManager.instance.PlaySound(audioClips[5] as AudioClip);
			}
			else
			{
				StandingA();
			}
		}
		comboTime.timerComplete += () => {started = false; if (attackCount >=2) comboEnd (); attackCount = 0; };
	}
	public void comboEnd()
	{
		float attackLegnth = 0.25f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1.0f, 0.5f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		
		int damage = 5;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                                knockBack, state, stateDuration));

		animControl.playTime ("MarioCombo3", 0.25f);
		AudioManager.instance.PlaySound(audioClips[6] as AudioClip);
		
	}
	public override void LeftRightA()
	{
		//Forward Kick
		//Can also be executed diagonally
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		float attackLegnth = 0.25f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1.0f, 0.3f, 0.0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		//Rotate if executed diagonally
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		
		int damage = 5;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		animControl.playTime ("MarioKick", 0.2f);
		AudioManager.instance.PlaySound(audioClips[4] as AudioClip);
		
	}
	public override void DownA()
	{
		//Crouch Kick: Has Moderate delay
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.down);
			else
				hasItem = false;
		}
		float attackLegnth = 0.25f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1f, -0.2f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		
		int damage = 6;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		animControl.playTime ("MarioKick", 0.2f);
		AudioManager.instance.PlaySound(audioClips[6] as AudioClip);
	}
	public override void UpA()
	{
		// Upward Punch
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		float attackLegnth = 0.25f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (0.0f, 1.6f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.zero;
		float rotationSpeed = 0.0f;
		
		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
		
		int damage = 3;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		animControl.playTime ("Mario_UpperCut", 0.2f);
		AudioManager.instance.PlaySound(audioClips[3] as AudioClip);
	}
	public override void SprintA()
	{
		//Slide Kick
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
			else
				hasItem = false;
		}
		float temp = 0;
		if (transform.rotation == Quaternion.Euler(new Vector3 (0f, 180f, 0f)))
		{
			temp = -100f;
		}
		else if (transform.rotation == Quaternion.identity)
		{
			temp = 100f;
		}
		
		float attackLegnth = 1f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.6f, 0.2f);
		Vector3 position = new Vector3 (1f, -0.2f, 0f);
		Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
		float lerpSpeed = 0.0f;
		bool pivot = false;
		Vector3 rotationDirection = Vector3.up;
		float rotationSpeed = 0.0f;
		
		int damage = 2;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;
		
		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		// Kirby Dashing A Animation
		// Kirby Dashing A Sound
		
		animControl.playTime ("MarioSlideKick", 0.9f);
		AudioManager.instance.PlaySound(audioClips[14] as AudioClip);
		
	}
	public override void NeutralAAir()
	{
		//Drop Kick
		//The kick has a long duration
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		float attackLegnth = 1.0f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.8f, 0.5f);
		Vector3 position = new Vector3 (1.0f, 0.0f, 0.2f);
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
		
		// Neutral A Air Animation
		// Neutral A Air Sound 
		
		animControl.playTime ("MarioSlideKick", 1.0f);
		AudioManager.instance.PlaySound(audioClips[4] as AudioClip);
		
	}
	public override void UpAir()
	{
		//Flip Kick
		//Mario Kicks Upward
		//SHOULD BE DONE -Audio
		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
			return;
		if (hasItem)
		{
			if (GetComponentInChildren<ItemBaseScript>())
				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.up);
			else
				hasItem = false;
		}
		float attackLegnth = 0.7f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 position = new Vector3 (1.0f, -0.6f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.forward;
		float rotationSpeed = 300.0f;
		
		int damage = 3;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;

		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		// Up Air Animation
		// Up Air Sound
		
		animControl.playTime ("MarioBackflip", 0.75f);
		AudioManager.instance.PlaySound(audioClips[18] as AudioClip);
	}
	public override void DownAir()
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
		float attackLegnth = 0.6f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.75f, 0.5f);
		Vector3 position = new Vector3 (1.0f, 0.0f, 0f);
		Vector3 lerpVelocity = Vector3.zero;
		float lerpSpeed = 0f;
		bool pivot = true;
		Vector3 rotationDirection = Vector3.up;
		float rotationSpeed = 1200.0f;
		
		int damage = 3;
		float knockBack = 1.0f;
		PlayerStates.disabledAndProtectiveStates state = PlayerStates.disabledAndProtectiveStates.FLINCHED;
		float stateDuration = 0.5f;

		StartCoroutine(AttackMovement(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, damage,
		                              knockBack, state, stateDuration));
		
		// Down Air Animation
		// Down Air Sound

		AudioManager.instance.PlaySound(audioClips[8] as AudioClip);
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
		float attackLegnth = 0.4f;
		Vector3 boxCollider = new Vector3 (0.5f, 0.75f, 0.5f);
		Vector3 position = new Vector3 (1.0f, 0.5f, 0f);
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
		
		// Left Air Animation
		// Left Air Sound

		animControl.playTime ("MarioSuperPunch", 0.35f);
		AudioManager.instance.PlaySound(audioClips[6] as AudioClip);
	}
//	public override void UpSmashA()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		if (hasItem)
//		{
//			if (GetComponentInChildren<ItemBaseScript>())
//				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
//			else
//				hasItem = false;
//		}
//		float attackLegnth = 0.2f;
//		Vector3 boxCollider = new Vector3 (3.0f, 0.4f, 0.1f);
//		Vector3 position = new Vector3 (1.0f, 0f, 0f);
//		Vector3 lerpVelocity = Vector3.zero;
//		float lerpSpeed = 0f;
//		bool pivot = true;
//		Vector3 rotationDirection = Vector3.forward;
//		float rotationSpeed = 1200.0f;
//		
//		if (!started)
//		{
//			smashTime = new Timer (1.2f);
//			started = true;
//			StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
//			                           pivot, rotationDirection, rotationSpeed));
//		}
//		smashTime.timerComplete += () => {started = false;};
//	}
//	public override void DownSmashA()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		if (hasItem)
//		{
//			if (GetComponentInChildren<ItemBaseScript>())
//				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.down);
//			else
//				hasItem = false;
//		}
//		float attackLegnth = 0.6f;
//		Vector3 boxCollider = new Vector3 (3.5f, 0.8f, 0.1f);
//		Vector3 position = new Vector3 (0f, -0.5f, 0f);
//		Vector3 lerpVelocity = Vector3.zero;
//		float lerpSpeed = 0f;
//		bool pivot = false;
//		Vector3 rotationDirection = Vector3.down;
//		float rotationSpeed = 1200.0f;
//		
//		if (!started)
//		{
//			smashTime = new Timer (1.2f);
//			started = true;
//			StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
//			                           pivot, rotationDirection, rotationSpeed));
//		}
//		smashTime.timerComplete += () => {started = false;};
//	}
//	public override void LeftRightSmashA()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		if (hasItem)
//		{
//			if (GetComponentInChildren<ItemBaseScript>())
//				GetComponentInChildren<ItemBaseScript>().FunctionAlpha(Vector3.forward);
//			else
//				hasItem = false;
//		}
//		float temp = 0;
//		if (transform.rotation == Quaternion.Euler(new Vector3 (0f, 180f, 0f)))
//		{
//			temp = -15f;
//		}
//		else if (transform.rotation == Quaternion.identity)
//		{
//			temp = 15f;
//		}
//		float attackLegnth = 0.2f;
//		Vector3 boxCollider = new Vector3 (1.5f, 0.8f, 0.1f);
//		Vector3 position = new Vector3 (1f, 0f, 0f);
//		Vector3 lerpVelocity = new Vector3 (temp, 0f, 0f);
//		float lerpSpeed = 1000f;
//		bool pivot = false;
//		Vector3 rotationDirection = Vector3.zero;
//		float rotationSpeed = 0f;
//		
//		if (!started)
//		{
//			smashTime = new Timer (1.2f);
//			started = true;
//			StartCoroutine(SmashAttack(attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed,
//			                           pivot, rotationDirection, rotationSpeed));
//		}
//		smashTime.timerComplete += () => {started = false;};
//		
//		// Left A Smash Animarion 
//		// Left A Smash Sound 
//	}
//	public override void NeutralB()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		float attackLegnth = 100f;
//		Vector3 boxCollider = new Vector3 (5f, 5f, 0.5f);
//		Vector3 position = new Vector3 (1f, 0f, 0f);
//		Vector3 lerpVelocity = Vector3.zero;
//		float lerpSpeed = 0f;
//		bool pivot = false;
//		Vector3 rotationDirection = Vector3.zero;
//		float rotationSpeed = 0.0f;
//		bool buttonHold = true;
//		bool neutralB = true;
//		
//		StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {}, neutralB));
//		
//		// Neutral B Animation
//		// Neutral B Sound
//	}
//	public override void UpSpecialB()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		float attackLegnth = 0.3f;
//		Vector3 boxCollider = new Vector3 (3f, 1f, 0.5f);
//		Vector3 position = new Vector3 (1f, 0f, 0f);
//		Vector3 lerpVelocity = new Vector3(0f, 50f, 0f);
//		float lerpSpeed = 100f;
//		bool pivot = false;
//		Vector3 rotationDirection = Vector3.zero;
//		float rotationSpeed = 0.0f;
//		bool buttonHold = false;
//		bool neutralB = false;
//		
//		StartCoroutine (SpecialMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed, buttonHold, ()=> {UpBEnd();}, neutralB));
//		
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
//	
//	public override void DownSpecialB()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		float attackLegnth = 0.5f;
//		Vector3 boxCollider = new Vector3 (2.0f, 1.5f, 0.2f);
//		Vector3 position = new Vector3 (1.0f, 0f, 0.3f);
//		Vector3 lerpVelocity = Vector3.zero;
//		float lerpSpeed = 0f;
//		bool pivot = true;
//		Vector3 rotationDirection = Vector3.up;
//		float rotationSpeed = 550.0f;
//		
//		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
//		// Down B Special Animarion 
//		// Down B Special Sound 
//	}
//	public override void LeftRightSpecialB()
//	{
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.FROZEN))
//			return;
//		float attackLegnth = 0.5f;
//		Vector3 boxCollider = new Vector3 (2.0f, 1.5f, 0.2f);
//		Vector3 position = new Vector3 (1.0f, 0f, 0.3f);
//		Vector3 lerpVelocity = Vector3.zero;
//		float lerpSpeed = 0f;
//		bool pivot = true;
//		Vector3 rotationDirection = Vector3.up;
//		float rotationSpeed = 550.0f;
//		
//		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
//		// Left B Special Animarion 
//		// Left B Special Sound 
//	}
//	public override void AGrab()
//	{
//		print ("Kirby A Grab was called");
//		// A Grab Animation
//		// A Grab Sound
//	}
//	public override void UpThrow()
//	{
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
//	
//	public IEnumerator AttackMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
//	                                  bool pivot, Vector3 rotationDirection, float rotationSpeed)
//	{
//		playerStates.disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
//		hitCollider.SetActive (true);
//		
//		while (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
//		{
//			disabledStates.vAttackLength = attackLength;
//			
//			hitCollider.transform.localPosition = position;
//			hitCollider.transform.localScale = boxCollider;
//			
//			rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
//			
//			if (pivot)
//				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
//			else
//				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
//			
//			yield return null;
//		}
//	}
	
//	public override void ResetAttack()
//	{
//		if (disabledStates.lockTime != null)
//			disabledStates.lockTime.Kill ();
//		
//		hitCollider.GetComponent<HitCollider> ().otherPlayer = null;
//		hitCollider.GetComponent<HitCollider> ().hitPlayer = false;
//		hitCollider.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
//		hitCollider.transform.localPosition = Vector3.zero;
//		hitCollider.SetActive (false);
//		hitCollider.transform.localRotation = Quaternion.identity;
//		
//		smashBar.GetComponentInParent<Canvas> ().transform.localPosition = new Vector3 (300f, 300f, 300f);
//		
//		if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
//			playerStates.disabledStates.Remove (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
//		
//		if (parent != null)
//		{
//			parent.transform.localPosition = Vector3.zero;
//			parent.transform.localRotation = Quaternion.identity;
//		}
//	}
	
//	public override IEnumerator ComboAttack (float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, bool pivot, Vector3 rotationDirection, float rotationSpeed)
//	{
//		hitCollider.SetActive (true);
//		while (Input.GetButton(inputManager.playerName + "_Attack"))
//		{
//			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
//			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;
//			
//			disabledStates.vAttackLength = attackLength;
//			
//			hitCollider.transform.localPosition = new Vector3 (1f, Random.Range(-1f, 1f), 0f);
//			hitCollider.transform.localScale = boxCollider;
//			
//			rigidBody.velocity = Vector3.Lerp (this.rigidBody.velocity, lerpVelocity, lerpSpeed * Time.deltaTime);
//			
//			if (pivot)
//				parent.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
//			else
//				hitCollider.transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
//			
//			yield return null;
//		}
//		ResetAttack ();
//		comboTime.Kill ();
//	}
	
//	public override IEnumerator SmashAttack (float attackLegnth, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed,
//	                                         bool pivot, Vector3 rotationDirection, float rotationSpeed)
//	{
//		smashBar.GetComponentInParent<Canvas> ().transform.localPosition = new Vector3 (0f, 2f, 0f);
//		while(Input.GetButton(inputManager.playerName + "_Attack") && started)
//		{
//			inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
//			inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
//			
//			yield return null;
//		}
//		
//		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
//		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
//		
//		StartCoroutine (AttackMovement (attackLegnth, boxCollider, position, lerpVelocity, lerpSpeed, pivot, rotationDirection, rotationSpeed));
//		smashTime.Kill ();
//	}
	
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
			
			//			if (hitCollider.GetComponent<HitCollider> ().otherPlayer != null && neutralB)
			//			{
			//				eatenPlayer = hitCollider.GetComponent<HitCollider> ().otherPlayer;
			//				eatenPlayer.GetComponent<PlayerStates>().disabledStates.Add(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);
			//				
			//				eatenPlayer.transform.position = Vector3.Lerp(eatenPlayer.transform.position, this.transform.position, 10f * Time.deltaTime);
			//				if (Vector3.Distance(eatenPlayer.transform.position, this.transform.position) < 0.2f)
			//				{
			//					eatenPlayer.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			//					eatenPlayer.transform.position = this.transform.position;
			//					eatenPlayer.transform.SetParent(this.transform);
			//					eatenPlayer.GetComponent<Rigidbody>().isKinematic = true;
			//				}
			//			}
			
			yield return null;
		}
		ResetAttack ();
		if (end != null)
			end ();
		
	}
}



















