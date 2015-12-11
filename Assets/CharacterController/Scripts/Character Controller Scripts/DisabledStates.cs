using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisabledStates : MonoBehaviour 
{
	public PhysicMaterial bouncy;
	PlayerStates playerStates;
	CharacterInputManager inputManager;
	BaseCharacter character;
	Dictionary<PlayerStates.disabledAndProtectiveStates, System.Action<float>> stateDict = new Dictionary<PlayerStates.disabledAndProtectiveStates, System.Action<float>>();
	private float attackLength;
	public float vAttackLength { get {return attackLength;} set {attackLength = value;} }

	bool started = false;
	public Timer lockTime;
	// Use this for initialization
	void Awake () 
	{
        character = this.gameObject.GetComponent<BaseCharacter>();
        playerStates = this.gameObject.GetComponent<PlayerStates>();
        inputManager = this.gameObject.GetComponent<CharacterInputManager> ();
	}

	void Start()
	{
        character = this.gameObject.GetComponent<BaseCharacter>();
        playerStates = this.gameObject.GetComponent<PlayerStates>();
        inputManager = this.gameObject.GetComponent<CharacterInputManager>();
        AddKeys ();
	}

	// Update is called once per frame
	public void LateUpdate () 
	{
		System.Action<float> value;
		foreach (PlayerStates.disabledAndProtectiveStates states in playerStates.disabledStates)
		{
			if (stateDict.TryGetValue(states, out value))
			{
				value(attackLength);
			}
		}
	}

	public void AbilityLock(float attackLength)
	{
		LockAll ();
		if (!started)
		{
			lockTime = new Timer (attackLength);
			started = true;
		}
		lockTime.timerComplete += () => {character.ResetAttack (); started = false;};
	}
	
	public void LockAll()
	{
		inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
		inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = inputManager.spamButton = false;
	}

	public void AddKeys()
	{
		stateDict.Add (PlayerStates.disabledAndProtectiveStates.ABILITYLOCK, AbilityLock);
	}
}
