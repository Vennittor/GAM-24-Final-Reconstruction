//Handles all the Inputs the player puts in

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HelperFunctions;

public class CharacterInputManager : MonoBehaviour 
{
	//Inputs start at the top
	//flow down through disabled states
	//get passed as inputs to current active movement state

	//Character Stats
	float weight; 
	float speed;
	float jumpHeight;
	int jumpMax;
	int jumpCount;
	
	//Jobs
	public Job standing, walking, crouching, sprinting, air, onLedge, shielding, grabbing;

	//Timers
	Timer smashDelay;
	bool started;

	//Components
	public string playerName;
	PlayerStates playerStates;
	Rigidbody rigidBody;
	Collider collider;

	//Ground Check
	float groundRayCount = 4;
	float raySpacing;
	public bool grounded;
	BaseCharacter character;

	//Input
	public float leftInput, rightInput, upInput, downInput;
	public bool shieldButton, jumpButton, grabButton, attackButton, specialButton, spamButton, spamSpecial;
	List<float> leftList = new List<float> ();
	List<float> rightList = new List<float> ();
	List<float> downList = new List<float> ();
	float leftTotal, rightTotal, downTotal;

	void Awake()
	{
		playerStates = this.gameObject.GetComponent<PlayerStates> ();
		playerName = this.name;
		rigidBody = this.gameObject.GetComponent<Rigidbody> ();
		collider = this.gameObject.GetComponent<Collider> ();
		collider.material = null;
		rigidBody.freezeRotation = true;
		jumpCount = jumpMax;
	}

	void Start()
	{
		playerStates.moveState = PlayerStates.movementStates.STANDING;
		character = GetComponent<BaseCharacter> ();
		weight = character.weight;
		speed = character.speed;
		jumpMax = character.jumpMax;
		jumpHeight = character.jumpHeight;
		Physics.IgnoreLayerCollision(9,9, true);
	}

	void Update()
    {
		CheckGround ();
	}

	void LateUpdate()
	{
		InputToVariables ();
		grounded = false;
	}
	
	public IEnumerator standingState(System.Action changeToWalking, System.Action changeToSprinting, System.Action changeToAir,
	                          System.Action changeToCrouching, System.Action changeToShielding, System.Action changeToGrabbing)
	{
		while (playerStates.moveState == PlayerStates.movementStates.STANDING)
		{
			if (grounded)
			{
				if (jumpButton && jumpCount == jumpMax && !character.frozen)
				{
                    //Input -> Physics -> Gravity -> set to -80
					rigidBody.AddForce(0f, 16 * ((jumpHeight * jumpHeight) / weight), 0f);
				}

				if (leftInput < -0.1f && attackButton || rightInput > 0.1f && attackButton)
				{
					yield return null;
					if (leftInput < -0.1f)
						transform.rotation = Quaternion.Euler(new Vector3 (0f, 180f, 0f));
					else if (rightInput > 0.1f)
						transform.rotation = Quaternion.identity;

					if (leftInput < -0.7f || rightInput > 0.7f)
						character.LeftRightSmashA();
					else
						character.LeftRightA();
				}
				else if (downInput < -0.1f && attackButton)
				{
					yield return null;
					if (downInput < -0.85f)
						character.DownSmashA();
					else
						character.DownA();
				}
				else if (upInput > 0.1f && attackButton)
				{
					yield return null;
					if (upInput > 0.7f)
						character.UpSmashA();
					else 
						character.UpA();
				}

				if (character.attackCount >= 2)
				{
					if (spamButton && leftInput >= -0.1f && rightInput <= 0.1f)
						character.ComboA();
				}
				else
				{
					if (attackButton && leftInput >= -0.1f && rightInput <= 0.1f)
						character.ComboA();
					else if (spamButton && leftInput >= -0.1f && rightInput <= 0.1f && !character.hasItem)
						character.StandingA();
				}

				if (leftInput < -0.1f && specialButton || rightInput > 0.1f && specialButton)
					character.LeftRightSpecialB();
				else if (upInput > 0.1f && specialButton)
					character.UpSpecialB();
				else if (downInput < -0.1f && specialButton)
					character.DownSpecialB();
				else if (specialButton)
					character.NeutralB();


				if (!rigidBody.velocity.Approximate(1.0f))
				{
					if (!playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
						rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, rigidBody.velocity/100.0f, 0.25f * Time.deltaTime);
				}
				else
				{
					if (leftInput < 0)
					{
						leftList.Add(leftInput);
						if (leftList.Count > 3)
							leftList.RemoveAt(0);

						if (leftList.Count == 3)
						{
							transform.rotation = Quaternion.Euler(new Vector3 (0f, 180f, 0f));

							if (LeftSprint)
								changeToSprinting();
							else
								changeToWalking();
						}
					}
					else if (rightInput > 0)
					{
						rightList.Add(rightInput);
						if (rightList.Count > 3)
							rightList.RemoveAt(0);

						if (rightList.Count == 3)
						{
							transform.rotation = Quaternion.identity;
							if (RightSprint)
								changeToSprinting();
							else
								changeToWalking();
						}
					}

					if (downInput < 0f)
					{
						downList.Add(downInput);
						if (downList.Count > 3)
							downList.RemoveAt(0);
						
						if (downList.Count == 3)
						{
							if (PlatformDown)
							{
								Physics.IgnoreLayerCollision(7,8, true);
							}
							else
								changeToCrouching();
						}
					}
					
					if (shieldButton)
						changeToShielding();
					if (grabButton)
						changeToGrabbing();	
				}
			}
			else
				changeToAir();

			yield return null;
		}
	}

	public IEnumerator walkingState(System.Action changeToStanding, System.Action changeToAir, System.Action changeToShielding, System.Action changeToGrabbing)
	{
		while (playerStates.moveState == PlayerStates.movementStates.WALKING)
		{
			if (grounded)
			{
				if (jumpButton && jumpCount == jumpMax && !character.frozen)
				{
					//Input -> Physics -> Gravity -> set to -80
					rigidBody.AddForce(0f, 16 * ((jumpHeight * jumpHeight) / weight), 0f);
				}

				if (leftInput < -0.1f && attackButton || rightInput > 0.1f && attackButton)
				{
					yield return null;
					if (leftInput < -0.7f || rightInput > 0.7f)
						character.LeftRightSmashA();
					else
						character.LeftRightA();
				}

				if (leftInput < -0.1f && specialButton || rightInput > 0.1f && specialButton)
					character.LeftRightSpecialB();
				else if (upInput > 0.1f && specialButton)
					character.UpSpecialB();
				else if (downInput < -0.1f && specialButton)
					character.DownSpecialB();

				if (leftInput == 0 && rightInput == 0)
					changeToStanding();
				else if (downInput < -0.8f)	
					changeToStanding();
				if (shieldButton)
					changeToShielding();
				if (grabButton)
					changeToGrabbing();	
			}
			else
				changeToAir();

			Vector3 targetVelocity;

			if (leftInput < 0)
				targetVelocity = new Vector3 ((leftInput),0,0);
			else
				targetVelocity = new Vector3 ((rightInput),0,0);

			targetVelocity *= speed/weight;
            if(!character.frozen)
			    rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, targetVelocity, 10.0f * Time.deltaTime);

			yield return null;
		}
	}

	public IEnumerator sprintingState(System.Action changeToStanding, System.Action changeToAir,
	                                  System.Action changeToShielding, System.Action changeToGrabbing)
	{
		while(playerStates.moveState == PlayerStates.movementStates.SPRINTING)
		{
			if (grounded)		
			{
				if (jumpButton && jumpCount == jumpMax && !character.frozen)
				{
                    
					//Input -> Physics -> Gravity -> set to -80
					rigidBody.velocity /= 5.0f;
					rigidBody.AddForce(0f, 16 * ((jumpHeight * jumpHeight) / weight), 0f);
				}

				if (attackButton)
					character.SprintA();
				if (leftInput < -0.1f && specialButton || rightInput > 0.1f && specialButton)
					character.LeftRightSpecialB();
				else if (upInput > 0.1f && specialButton)
					character.UpSpecialB();
				else if (downInput < -0.1f && specialButton)
					character.DownSpecialB();

				if (leftInput > -0.1f && rightInput < 0.1f)
					changeToStanding();
				if (downInput < -0.8f)
					changeToStanding();
				if (shieldButton)
					changeToShielding();
				if (grabButton)
					changeToGrabbing();	
			}
			else
				changeToAir();

			Vector3 targetVelocity = Vector3.zero;

			if (leftInput < -0.4f)
			{
				targetVelocity = new Vector3 (-1,0,0);
			}
			else if (rightInput > 0.4f)
			{
				targetVelocity = new Vector3 (1,0,0);
			}

			if (targetVelocity != Vector3.zero)
			{
				targetVelocity *= speed/(float)weight * 2.0f;
                if(!character.frozen)
				    rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, targetVelocity, 10.0f * Time.deltaTime);
			}

			yield return null;
		}
	}

	public IEnumerator airState(System.Action changeToStanding)
	{
		while (playerStates.moveState == PlayerStates.movementStates.AIR)
		{
			if (grounded)
			{
				changeToStanding ();
				//character.StopAllCoroutines();
				character.ResetAttack();
			}

			if (upInput > 0.2f && attackButton)
				character.UpAir();
			else if (leftInput < -0.1f && attackButton|| rightInput > 0.1f && attackButton)
				character.LeftRightAir();
			else if (downInput < -0.3f && attackButton)
				character.DownAir();
			else if (attackButton)
				character.NeutralAAir();

			if (leftInput < -0.1f && specialButton || rightInput > 0.1f && specialButton)
				character.LeftRightSpecialB();
			else if (upInput > 0.1f && specialButton)
				character.UpSpecialB();
			else if (downInput < -0.1f && specialButton)
				character.DownSpecialB();
			else if (specialButton)
				character.NeutralB();

			if (jumpButton && jumpCount > 0 && !character.frozen)
			{
				//Input -> Physics -> Gravity -> set to -80
				rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, 0f);
				rigidBody.AddForce(0f, (16 * ((jumpHeight * jumpHeight) / weight)) - 100 * (jumpMax-jumpCount), 0f);
				jumpCount--;
			}
			Vector3 targetVelocity = Vector3.zero;

			if (leftInput < -0.15f)
			{
				transform.rotation = Quaternion.Euler(new Vector3 (0f, 180f, 0f));
				targetVelocity = new Vector3 (leftInput, 0, 0);
			}
			else if (rightInput > 0.15f)
			{
				transform.rotation = Quaternion.identity;
				targetVelocity = new Vector3 (rightInput, 0, 0);
			}

			Physics.IgnoreLayerCollision(7,8, false);
			if (downInput < -0.1f)
			{
				Physics.IgnoreLayerCollision(7,8, true);
				targetVelocity += new Vector3 (0, downInput, 0);
			}

			targetVelocity *= speed/weight;

			if (targetVelocity != null && !character.frozen)
				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector3 (targetVelocity.x/1.5f ,rigidBody.velocity.y + targetVelocity.y, 0f), 4.0f * Time.deltaTime);

			yield return null;
		}
	}

	public IEnumerator crouchState (System.Action changeToStanding, System.Action changeToShielding, System.Action changeToAir)
	{
		while (playerStates.moveState == PlayerStates.movementStates.CROUCHING)
		{
			if (jumpButton && jumpCount == jumpMax && !character.frozen)
			{
				//Input -> Physics -> Gravity -> set to -80
				rigidBody.AddForce(0f, 16 * ((jumpHeight * jumpHeight) / weight), 0f);
			}
			if (grounded)
			{
				if (downInput < -0.1f && attackButton)
					character.DownA();

				if (leftInput < -0.1f && specialButton || rightInput > 0.1f && specialButton)
					character.LeftRightSpecialB();
				else if (upInput > 0.1f && specialButton)
					character.UpSpecialB();
				else if (downInput < -0.1f && specialButton)
					character.DownSpecialB();

				if (downInput > -0.1f)
					changeToStanding();
				if (shieldButton)
					changeToShielding();
			}
			else
				changeToAir();

			Vector3 targetVelocity = Vector3.zero;

			if (leftInput < -0.15f)
			{
				transform.rotation = Quaternion.Euler(new Vector3 (0f, 180f, 0f));
				targetVelocity = new Vector3 (leftInput, 0, 0);
			}
			else if (rightInput > 0.15f)
			{
				transform.rotation = Quaternion.identity;
				targetVelocity = new Vector3 (rightInput, 0, 0);
			}

			targetVelocity *= speed/weight;
			if(!character.frozen)
			  rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, targetVelocity/1.5f, 10.0f * Time.deltaTime);

			yield return null;
		}
	}
	
	public bool PlatformDown
	{
		get
		{
			foreach (float input in downList)
			{
				downTotal += input;
			}
			downTotal = 2*downTotal/downList.Count;
			if (downTotal < -0.7f)
			{
				downTotal = 0;
				downList.Clear();
				return true;
			}
			else
			{
				downTotal = 0;
				downList.Clear();
				return false;
			}
		}
	}

	public bool LeftSprint
	{
		get
		{
			foreach(float input in leftList)
			{
				leftTotal += input;
			}
			leftTotal = 2*leftTotal/leftList.Count;
			if (leftTotal < -0.4f)
			{
				leftTotal = 0;
				leftList.Clear();
				return true;
			}
			else
			{
				leftTotal = 0;
				leftList.Clear();
				return false;
			}
		}
	}

	public bool RightSprint
	{
		get
		{
			foreach(float input in rightList)
			{
				rightTotal += input;
			}
			rightTotal = 2*rightTotal/rightList.Count;
			if (rightTotal > 0.4f)
			{
				rightTotal = 0;
				rightList.Clear();
				return true;
			}
			else
			{
				rightTotal = 0;
				rightList.Clear();
				return false;
			}
		}
	}

	void CheckGround()
	{
        Bounds bounds = collider.bounds;
		bounds.Expand (0.015f * -2);
        Vector3 bottomLeft = new Vector3 (bounds.min.x, bounds.min.y, bounds.min.z);
		raySpacing = bounds.size.x / (groundRayCount - 1);

		for (int i=0; i < groundRayCount; i++)
		{
			Debug.DrawRay(bottomLeft + Vector3.right * raySpacing * i, Vector3.down * 0.1f, Color.red);
			RaycastHit hit;
			if (Physics.Raycast(bottomLeft + Vector3.right * raySpacing * i, Vector3.down, out hit, 0.1f)) 
		    {
				if (hit.collider.tag == "Floor")
				{
					jumpCount = jumpMax;
					grounded = true;
				}
			}
		}
	}

	void InputToVariables()
	{
		if (!playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
		{
			if (Input.GetAxis (playerName + "_Horizontal") != 0)
			{
				if (Input.GetAxis (playerName + "_Horizontal") < 0)
					leftInput = Input.GetAxis (playerName + "_Horizontal");
				else if (Input.GetAxis (playerName + "_Horizontal") > 0)
					rightInput = Input.GetAxis (playerName + "_Horizontal");
			}
			else
			{
				leftInput = rightInput = 0;
			}
			
			if (Input.GetAxis (playerName + "_Vertical") != 0)
			{
				if (Input.GetAxis (playerName + "_Vertical") < 0)
					downInput = Input.GetAxis (playerName + "_Vertical");
				else if (Input.GetAxis (playerName + "_Vertical") > 0)
					upInput = Input.GetAxis (playerName + "_Vertical");
			}
			else
			{
				upInput = downInput = 0;
			}
	//		
	//		if (Input.GetButton (playerName + "_Shield"))
	//			shieldButton = true;
	//		else
	//			shieldButton = false;

			if (Input.GetButtonDown (playerName + "_Jump"))
				jumpButton = true;
			else
				jumpButton = false;
	//
	//		if (Input.GetButtonDown (playerName + "_Grab"))
	//			grabButton = true;
	//		else
	//			grabButton = false;

			if (Input.GetButtonDown (playerName + "_Attack"))
				attackButton = true;
			else
				attackButton = false;

			if (Input.GetButton (playerName + "_Attack"))
				spamButton = true;
			else
				spamButton = false;

			if (Input.GetButtonDown (playerName + "_Special"))
				specialButton = true;
			else
				specialButton = false;

			if (Input.GetButton (playerName + "_Special"))
				spamSpecial = true;
			else
				spamSpecial = false;
		}
	}
}