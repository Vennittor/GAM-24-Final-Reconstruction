//Player States will handle the switching between the movement states and will handle the active disabled and protective states


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//[RequireComponent(typeof(CharacterInputManager))]
public class PlayerStates : MonoBehaviour 
{
	//Switch state to determine which movement state it is currently in
	//Standing, Walking, Crouching, Sprinting, Air, OnLedge, Shielding, Grabbing

	//Will have conditions that change the current movement state the character is in

	//Active disabled and protective states are held in a list
	//when one is added to the list it starts a (timer or coroutine???) modifying inputs

	CharacterInputManager inputManager;
	public enum movementStates
	{
		STANDING, WALKING, CROUCHING, SPRINTING, AIR, ONLEDGE, SHIELDING, GRABBING
	}

	public List<disabledAndProtectiveStates> disabledStates = new List<disabledAndProtectiveStates>();
	public enum disabledAndProtectiveStates
	{
		GRABBED, HELPLESS, BURIED, ASLEEP, FROZEN, REELING, STUNNED, FLINCHED, SLOWMO, LYING, VULNERABLE, THROWN,
		NOKNOCKBACK, NODAMAGE, UNCOLLIDABLE, GRABIMMUNE, ABILITYLOCK, FLINCHIMMUNE
	}

	[SerializeField][ReadOnlyAttribute]
	private movementStates _moveState;
	public movementStates moveState
	{
		get
		{
			return _moveState;
		}
		set
		{
			ExitState(_moveState);
			_moveState = value;
			EnterState(_moveState);
		}
	}

	void Awake()
	{
		inputManager = this.gameObject.GetComponent<CharacterInputManager> ();
	}
    void Start()
    {
      inputManager = GetComponent<CharacterInputManager>();
    }

	void EnterState (movementStates state)
	{
        if (inputManager != null)
		{
            switch (state)
			{
			case movementStates.STANDING:
				this.GetComponent<MeshRenderer>().material.color = Color.black;
				inputManager.standing = new Job (inputManager.standingState(
												()=> {moveState = movementStates.WALKING;},
												()=> {moveState = movementStates.SPRINTING;},
												()=> {moveState = movementStates.AIR;},
												()=> {moveState = movementStates.CROUCHING;},
												()=> {moveState = movementStates.SHIELDING;},
												()=> {moveState = movementStates.GRABBING;}),true);
				break;
			case movementStates.WALKING:
				this.GetComponent<MeshRenderer>().material.color = Color.blue;
				inputManager.walking = new Job (inputManager.walkingState(
												()=> {moveState = movementStates.STANDING;},
												()=> {moveState = movementStates.AIR;},
												()=> {moveState = movementStates.SHIELDING;},
												()=> {moveState = movementStates.GRABBING;}),true);
				break;
			case movementStates.SPRINTING:
				this.GetComponent<MeshRenderer>().material.color = Color.cyan;
				inputManager.sprinting = new Job (inputManager.sprintingState(
												()=> {moveState = movementStates.STANDING;},
												()=> {moveState = movementStates.AIR;},
												()=> {moveState = movementStates.SHIELDING;},
												()=> {moveState = movementStates.GRABBING;}),true);
				break;
			case movementStates.AIR:
				this.GetComponent<MeshRenderer>().material.color = Color.magenta;
				inputManager.air = new Job (inputManager.airState(
											()=> {moveState = movementStates.STANDING;}),true);
				break;
			case movementStates.CROUCHING:
				this.GetComponent<MeshRenderer>().material.color = Color.gray;
				inputManager.crouching = new Job (inputManager.crouchState(
												()=> {moveState = movementStates.STANDING;},
												()=> {moveState = movementStates.SHIELDING;},
												()=> {moveState = movementStates.AIR;}),true);
				break;
			case movementStates.GRABBING:
				this.GetComponent<MeshRenderer>().material.color = Color.green;
				break;
			case movementStates.SHIELDING:
				this.GetComponent<MeshRenderer>().material.color = Color.red;
				break;
			case movementStates.ONLEDGE:
				this.GetComponent<MeshRenderer>().material.color = Color.yellow;
				break;
			}
		}
	}

	void ExitState (movementStates state)
	{
		if (inputManager != null)
		{
			switch (state)
			{
			case movementStates.STANDING:
				if (inputManager.standing != null) 
					inputManager.standing.kill();
				break;
			case movementStates.WALKING:
				if (inputManager.walking != null) 
					inputManager.walking.kill();
				break;
			case movementStates.SPRINTING:
				if (inputManager.sprinting != null) 
					inputManager.sprinting.kill();
				break;
			case movementStates.CROUCHING:
				if (inputManager.crouching != null)
					inputManager.crouching.kill();
				break;
			case movementStates.GRABBING:
				if (inputManager.grabbing != null)
					inputManager.grabbing.kill();
				break;
			case movementStates.AIR:
				if (inputManager.air != null)
					inputManager.air.kill();
				break;
			case movementStates.SHIELDING:
				if (inputManager.shielding != null)
					inputManager.shielding.kill();
				break;
			case movementStates.ONLEDGE:
				if (inputManager.onLedge != null)
					inputManager.onLedge.kill();
				break;
			}
		}
	}

}