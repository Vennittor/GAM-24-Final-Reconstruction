using UnityEngine;
using System.Collections;

public class Hammer : ItemBaseScript
{
    public GameObject head;
    public override void Start()
    {
        damage = 20;
        base.Start();
    }
    public override void FunctionAlpha()
    {
        //transform.parent.gameObject.GetComponent<>().HammerEffect();
        int headDropChance = Random.Range(0, 100);
        if (headDropChance < 20)
        {
            head.transform.parent = null;
            head.GetComponent<BoxCollider>().enabled = true;
            head.GetComponent<Rigidbody>().isKinematic = false;
            this.damage = 5;
        }
            
        base.FunctionAlpha();
    }
    public override void Update()
    {
        base.Update();
    }
    void OnCollisionEnter(Collision other)
    {
        //applydamg
    }
}
