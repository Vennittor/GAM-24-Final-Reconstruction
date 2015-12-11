using UnityEngine;
using System.Collections;

public class ItemBaseScript : MonoBehaviour 
{
	public bool held = false;
	public bool thrown = false;
    public bool active = false;

	public int damage = 1;
	public int thrownDMG = 5;
    public float knockBack;

	public int durability = 1;

	public Rigidbody rb;

	public GameObject spawner;
    public GameObject trigger;

	public GameObject owner;
   
	// Use this for initialization
	public virtual void Start()
	{
		spawner = GameObject.Find("ItemSpawn");
		rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(10, 10, true);//Items needs to be on layer 10
        Physics.IgnoreLayerCollision(10, 9, true);//Players needs to be on layer 9
    }
	public virtual void Update()
	{
		if (durability <=0)
		{
			spawner.GetComponent<ItemSpawner>().itemsAwake.Remove(gameObject);
			Destroy(gameObject);
		}
        if (owner != null)
        {
            if (owner.GetComponent<BaseCharacter>().hasItem == false)
            {
                if (owner.GetComponent<CharacterInputManager>().attackButton)//base attack button
                {
                    Grabbed(owner);
                }
            }
        }
    }
	public virtual void Grabbed(GameObject owner)
	{
		held = true;
		transform.parent = owner.transform;
        BaseCharacter bc = owner.GetComponent<BaseCharacter>();
        transform.position = owner.transform.position + new Vector3(1f, 0, 0);
        owner.GetComponent<CharacterInputManager>().attackButton = false;
        owner.GetComponent<CharacterInputManager>().spamButton = false;
        bc.hasItem = true;
        trigger.SetActive(false);
        GetComponent<Collider>().enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = true;
	}
	public virtual void Released(Vector3 throwDirection = new Vector3())
	{

        Vector3 transVelocity = GetComponentInParent<Rigidbody>().velocity;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
     
        thrown = true;
        owner.GetComponent<BaseCharacter>().hasItem = false;

		held = false;

		transform.parent = null;
       CharacterInputManager input = owner.GetComponent<CharacterInputManager>();
        if (input.leftInput > .7f)
            throwDirection = Vector3.left;
        else if (input.rightInput > .7f)
            throwDirection = Vector3.right;
        else if (input.upInput > .7f)
            throwDirection = Vector3.up;
        else if (input.downInput > .7f)
            throwDirection = Vector3.down;
        if (throwDirection == new Vector3())
            throwDirection = Vector3.up;
        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
        rb.AddForce(transVelocity + throwDirection * 500);
        gameObject.layer = 11;
        owner = null;
	}
	public virtual void FunctionAlpha(Vector3 throwDirection = new Vector3())
	{

	}
	public virtual void FunctionBeta()
	{
		
	}
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BaseCharacter>())
        {
            if (owner == null)
            {
                owner = other.gameObject;
            }
        }
    }
  
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == owner)
        {
           if (!held)
            {
                owner = null;
            }
        }
    }
    public void AddDamage(GameObject player)
    {
        if(player.gameObject.GetComponent<BaseCharacter>())
            player.gameObject.GetComponent<BaseCharacter>().TakeDamage(damage, knockBack,
            PlayerStates.disabledAndProtectiveStates.ASLEEP, 0, transform);
    }

}
	

