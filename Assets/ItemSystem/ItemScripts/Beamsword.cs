using UnityEngine;
using System.Collections;

public class Beamsword : ItemBaseScript
{
    bool activeAttack = false;
    public override void Start()
    {
        damage = 5;
        knockBack = 1;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        //swingANimation
        if (!activeAttack)
            StartCoroutine("Swinging");

        base.FunctionAlpha();
    }
    void OnCollisionEnter(Collision other)
    {
        if(activeAttack)
        {
            if(other.transform != transform.parent)
            {
                if (other.gameObject.GetComponent<BaseCharacter>())
                    other.gameObject.GetComponent<BaseCharacter>().TakeDamage(damage, knockBack);
                Debug.Log("hit");
            }

        }

    }
    IEnumerator Swinging()
    {
        activeAttack = true;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 45)), 3);
        yield return new WaitForSeconds(.5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 3);
        activeAttack = false;

    }
}
