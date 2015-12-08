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

    public bool hasItem;
    public GameObject model = null;
    public Animation_Controller animControl = null;
	public virtual void Awake()
	{
        playerStates = this.gameObject.GetComponent<PlayerStates>();
        disabledStates = this.gameObject.GetComponent<DisabledStates>();
        inputManager = this.gameObject.GetComponent<CharacterInputManager>();
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), hitCollider.GetComponent<Collider>());
        hitCollider.SetActive(false);
        hitCollider.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
	public virtual void Update()
	{
		time = 0;
		if (smashTime != null)
		{
			time = smashTime.currentTime / smashTime.targetTime;

			smashBar.transform.localScale = new Vector3(time, smashBar.transform.localScale.z, smashBar.transform.localScale.z);
		}
        if(model != null)
        {
            if(playerStates.moveState == PlayerStates.movementStates.STANDING)
            {
                animControl.playLoop("Idle");
                if (inputManager.jumpButton)
                {
                    animControl.playTime("Jump");
                }
            }
            else if (playerStates.moveState == PlayerStates.movementStates.SPRINTING)
            {
                if (inputManager.jumpButton)
                {
                    animControl.playTime("Jump");
                }
                animControl.playLoop("Run");
            }
            else if(playerStates.moveState == PlayerStates.movementStates.WALKING)
            {
                if (inputManager.jumpButton)
                {
                    animControl.playTime("Jump");
                }
                animControl.playLoop("Walk");
            }
           else if(playerStates.moveState == PlayerStates.movementStates.AIR)
           {
                if (inputManager.jumpButton)
                {
                    animControl.playTime("Jump");
                }
                if (!animControl.anim.isPlaying)
                    animControl.playTime("Fall");
            }

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
	                                          bool pivot, Vector3 rotationDirection, float rotationSpeed, int damage, float knockBack, 
	                                          PlayerStates.disabledAndProtectiveStates state, float stateDuration)
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
    }

	public virtual void ResetAttack()
	{
        if (disabledStates.lockTime != null)
            disabledStates.lockTime.Kill();

        hitCollider.GetComponent<HitCollider>().otherPlayer = null;
        hitCollider.GetComponent<HitCollider>().hitPlayer = false;
        hitCollider.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        hitCollider.transform.localPosition = Vector3.zero;
        hitCollider.SetActive(false);
        hitCollider.transform.localRotation = Quaternion.identity;

        smashBar.GetComponentInParent<Canvas>().transform.localPosition = new Vector3(300f, 300f, 300f);

        if (playerStates.disabledStates.Contains(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK))
            playerStates.disabledStates.Remove(PlayerStates.disabledAndProtectiveStates.ABILITYLOCK);

        if (parent != null)
        {
            parent.transform.localPosition = Vector3.zero;
            parent.transform.localRotation = Quaternion.identity;
        }
    }

	public virtual IEnumerator ComboAttack(float attackLength, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed, 
	                                       bool pivot, Vector3 rotationDirection, float rotationSpeed)
	{
        hitCollider.SetActive(true);
        while (Input.GetButton(inputManager.playerName + "_Attack"))
        {
            inputManager.leftInput = inputManager.rightInput = inputManager.downInput = inputManager.upInput = 0f;
            inputManager.attackButton = inputManager.grabButton = inputManager.jumpButton = inputManager.shieldButton = inputManager.specialButton = false;

            disabledStates.vAttackLength = attackLength;

            hitCollider.transform.localPosition = new Vector3(1f, Random.Range(-1f, 1f), 0f);
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

	public virtual IEnumerator SmashAttack(float attackLegnth, Vector3 boxCollider, Vector3 position, Vector3 lerpVelocity, float lerpSpeed,
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
    }


	public virtual void TakeDamage(int damage, float knockBack, PlayerStates.disabledAndProtectiveStates state, float stateDuration, Transform hitTransform)
	{
		Vector3 direction;
		health += damage;
		//((((health/10 + health*damage/20) * 200/(weight+100) * 1.4f) + 18) * knockBack)

//		if (damage != 0 && knockBack != 0f)
//		{
//			direction = transform.position - hitTransform.position;
//			direction = Vector3.Normalize (direction);
//			direction = new Vector3 (direction.x, direction.y + 0.1f, 0f);
//
//			rigidBody.AddForce (direction * ((((health / 10 + health * damage / 20) * 200 / (weight + 100) * 1.4f) + 18) * knockBack) * 100f);
//		}

	}
}




















