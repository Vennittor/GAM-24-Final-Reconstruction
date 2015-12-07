using UnityEngine;
using System.Collections;

public class FireFlower :ItemBaseScript
{
    public GameObject hitBox;
    public override void Start()
    {
        durability = 7;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        durability -= 1 * (int)Time.deltaTime;
        hitBox.GetComponent<ParticleSystem>().Play();
        base.FunctionAlpha();
    }

   

}
