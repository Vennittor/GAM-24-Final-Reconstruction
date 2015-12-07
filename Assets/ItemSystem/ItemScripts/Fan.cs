using UnityEngine;
using System.Collections;

public class Fan: ItemBaseScript
{
    bool activeAttack = false;
    public override void Start()
    {
        damage = 2;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        //swingANimation
        if(!activeAttack)
            StartCoroutine("Swinging");

        base.FunctionAlpha();
    }
    void OnCollisionEnter(Collision other)
    {
        if (activeAttack)
        {
            if (other.transform != transform.parent)
            {
                //apply damage to collider
                Debug.Log("hit");
            }

        }

    }
    IEnumerator Swinging()
    {
        activeAttack = true;
        yield return new WaitForSeconds(1);
        activeAttack = false;
    }
}