using UnityEngine;
using System.Collections;

public class Star : ItemBaseScript
{
    public override void Start()
    {
        //InvokeRepeating("Bounce", 1.5f, .7f);
        base.Start();
    }
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        base.FunctionAlpha(throwDirection);
    }
    public override void Grabbed(GameObject owner)
    {
        owner.GetComponent<BaseCharacter>().Star(10);
        durability = 0;
    
    }
    public override void Update()
    {
        base.Update();
    }
    void Bounce()
    {   
        Debug.Log("Bounce");
        rb.AddForce((Vector3.up * 1000) + (new Vector3(Random.Range(-1,1.1f),0,0) * 500));
    }

}
