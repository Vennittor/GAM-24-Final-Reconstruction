using UnityEngine;
using System.Collections;
public class Pill : ItemBaseScript 
{
    public GameObject explosion;
	public bool spawn = false;
	void Awake()
	{
		
		durability = 1;
	}
	public override void Update()
	{
		if (spawn)
			FunctionBeta();
		base.Update();
	}
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        Released(throwDirection);
        base.FunctionAlpha(throwDirection);
    }
    public override void FunctionBeta()
	{
		int chance = Random.Range (0,100);
		if (chance<=25)
		{
            StartCoroutine("Explode");
		}
		else
		{
		ItemSelector select = spawner.GetComponent<ItemSelector>();
		GameObject a = Instantiate(select.SpawnItem(select.RandomDrop ()),
		                           transform.position,
		                           Quaternion.Euler(new Vector3(0,90,0))) as GameObject;
            spawner.GetComponent<ItemSpawner>().itemsAwake.Add(a);
            durability--;
        }
		
		base.FunctionBeta ();
	}
	void OnCollisionEnter(Collision other)
	{
        if (thrown)
            FunctionBeta();
	}
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Exploding");
    }
    IEnumerator Explode()
    {
        explosion.GetComponent<ParticleSystem>().Play();
        SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            mesh.enabled = false;
        }
        yield return new WaitForSeconds(1);
        durability = 0;
    }
}
