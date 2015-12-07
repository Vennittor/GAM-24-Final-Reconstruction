using UnityEngine;
using System.Collections;

public class ItemBaseScript : MonoBehaviour 
{
	public bool held = false;
	public bool thrown = false;

	public int damage = 1;
	public int thrownDMG = 5;

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
        if (throwDirection == new Vector3())
            throwDirection = Vector3.up;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        GetComponent<Collider>().enabled = true;
        rb.AddForce(transVelocity + throwDirection * 500);
        
        owner = null;
	}
	public virtual void FunctionAlpha(Vector3 throwDirection = new Vector3())
	{

	}
	public virtual void FunctionBeta()
	{
		
	}
    public void OnTriggerEnter(Collider other)
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
           if(!held)
            {
                owner = null;
            }
        }
    }

}
	

