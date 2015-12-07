using UnityEngine;
using System.Collections;

public class Head :ItemBaseScript
{
    public override void Start()
    {
        damage = 15;
        base.Start();
    }
    void OnCollisionEnter(Collision other)
    {
        if(thrown)
        {
            //applydmg
        }
    }

}
