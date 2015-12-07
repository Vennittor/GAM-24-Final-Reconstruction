using UnityEngine;
using System.Collections;

public class Star : ItemBaseScript
{
    public override void Start()
    {
        InvokeRepeating("Bounce", 2, 1);
        base.Start();
    }
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        base.FunctionAlpha(throwDirection);
    }
    public override void Grabbed(GameObject owner)
    {
        // invinc state
        durability = 0;
    
    }
    public override void Update()
    {
        base.Update();
    }
    void Bounce()
    {
        rb.AddForce(Vector3.up  + new Vector3(Random.Range(-1,2),0,0)* 100);
    }

}
