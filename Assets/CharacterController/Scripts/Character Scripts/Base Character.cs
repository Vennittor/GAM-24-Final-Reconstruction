using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour 
{
	public PlayerStates playerStates;
	public DisabledStates disabledStates;
	public CharacterInputManager inputManager;
	public GameObject parent;
	public Rigidbody rigidBody;
	public GameObject smashBar;
	public Timer comboTime, smashTime;
	public float weight; 
	public float speed;
	public float damageModifier; 
	public float defence; 
	public float jumpHeight;
	public int health; 
	public int jumpMax;
	public int attackCount;
	public bool started;
	public float time;
	public GameObject camera;

	public GameObject hitCollider;

	public virtual void Awake()
	{

	}
	public virtual void Update()
	{
		time = 0;
		if (smashTime != null)
		{
			time = smashTime.currentTime / smashTime.targetTime;

			smashBar.transform.localScale = new Vector3(time, smashBar.transform.localScale.z, smashBar.transform.localScale.z);
		}
	}
	public virtual void StandingA()
	{
		
	}
	public virtual void ComboA()
	{
		
	}
	public virtual void LeftRightA()
	{
		
	}
	public virtual void DownA()
	{
		
	}
	public virtual void UpA()
	{
		
	}
	public virtual void SprintA()
	{

	}
	public virtual void NeutralAAir()
	{

	}
	public virtual void UpAir()
	{

	}
	public virtual void DownAir()
	{

	}
	public virtual void LeftRightAir()
	{

	}
	public virtual void UpSmashA()
	{

	}
	public virtual void DownSmashA()
	{

	}
	public virtual void LeftRightSmashA()
	{

	}
	public virtual void NeutralB()
	{

	}
	public virtual void UpSpecialB()
	{

	}
	public virtual void DownSpecialB()
	{

	}
	public virtual void LeftRightSpecialB()
	{

	}
	public virtual void AGrab()
	{

	}
	public virtual void UpThrow()
	{

	}
	public virtual void DownThrow()
	{
	
	}
	public virtual void LeftRightThrow()
	{

	}
	public virtual void LedgeAttack()
	{

	}

	public virtual IEnumerator AttackMovement(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                           bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		yield return null;
	}

	public virtual void ResetAttack()
	{

	}

	public virtual IEnumerator ComboAttack(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                       bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		yield return null;
	}

	public virtual IEnumerator SmashAttack(float attackLegnth, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed,
	                                       bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
		yield return null;
	}
}
