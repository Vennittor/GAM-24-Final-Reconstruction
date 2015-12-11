using UnityEngine;
using System.Collections;

public class Shell : ItemBaseScript 
{
	public float timer =5.0f;

	Vector3 leftright = Vector3.zero;

	int hitCount = 0;

	public override void Start ()
	{
		base.Start();
	}
    public override void Update () 
	{
        if (!held && !thrown)
        {
            if (timer >= 0)
                timer -= Time.deltaTime;
            if (timer <= 0)
                FunctionBeta();
        }
        base.Update();
	}
	public override void FunctionAlpha (Vector3 throwDirection = default(Vector3))
	{
        Released(throwDirection);
        leftright = new Vector3(throwDirection.x, 0, 0);
        FunctionBeta();
		base.FunctionAlpha ();
	}
	public override void FunctionBeta ()
	{
		if (leftright == Vector3.zero) 
		{
			int a = Random.Range (0,2);
			if (a==0)
				leftright = new Vector3(-1,0,0);
			else
				leftright = new Vector3(1,0,0);
		}
		rb.AddForce (leftright * 10);
		base.FunctionBeta ();
	}
	void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.GetComponent<BaseCharacter>())
            AddDamage(other.gameObject);
        if (other.gameObject.name != "Floor") 
		{
			hitCount ++;
			if(hitCount>1)
			{
				if (other.transform.position.x < gameObject.transform.position.x) 
				{
					leftright = new Vector3 (1, 0, 0);
					//rb.velocity = leftright * 4;
					rb.velocity = leftright * 10;
				} 
				else 
				{
					leftright = new Vector3 (-1, 0, 0);
					//rb.velocity = leftright * 4;
					rb.velocity = leftright * 10;
				}
			}
		}
	}
}
