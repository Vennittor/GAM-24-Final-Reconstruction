using UnityEngine;
using System.Collections;

public class BobOmb : ItemBaseScript
{
    public GameObject rayThrower, explosion;
    public float timer = 4;

    public bool goRight = true;

    float walkSpeed = 3;
    // Use this for initialization
    public override void Start ()
    {
        damage = 5;
        knockBack = 3;
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        if(held == false && thrown == false)
            timer -= Time.deltaTime;
        if(timer<=0)
        {
            active = true;
            gameObject.layer = 11;
            Vector3 moveDir = Vector3.right;
            if (goRight)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                gameObject.transform.position += Vector3.right *  walkSpeed * Time.deltaTime;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                gameObject.transform.position += Vector3.left * walkSpeed * Time.deltaTime;
            }

            if (Physics.Raycast(rayThrower.transform.position, Vector3.down, 1))
            {
                Debug.Log("hitting");
            }
           else
            {
                goRight = !goRight;
            }
        }
              
        base.Update();
	}
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        Released(throwDirection);
        base.FunctionAlpha();
    }
    public override void FunctionBeta()
    {
        //explode
        StartCoroutine("Explode");
        base.FunctionBeta();
    }
    Vector3 PickDirection()
    {
        int randRoll = Random.Range(0, 2);
        if (randRoll == 0)
            return Vector3.right;
        else
            return Vector3.left;
    }
    void OnParticleCollision(GameObject other)
    {
       
    }
   void OnCollisionEnter(Collision other)
    {
        if (thrown)
            FunctionBeta();
        else if (active)
             {
            if (other.gameObject.GetComponent<BaseCharacter>())
                FunctionBeta();
             }
    }
    IEnumerator Explode()
    {
        trigger.SetActive(trigger);
        explosion.GetComponent<ParticleSystem>().Play();
       SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer mesh in meshes)
        {
            mesh.enabled = false;
        }
        yield return new WaitForSeconds(1);
        durability = 0;
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (active)
            AddDamage(other.gameObject);
        base.OnTriggerEnter(other);
    }
}
