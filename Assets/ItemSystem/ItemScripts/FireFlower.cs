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
        if (Input.GetKey(KeyCode.E))
        {
            durability -= 1 * (int)Time.deltaTime;
            hitBox.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.E))
            hitBox.SetActive(false);
        base.Update();
    }
    public override void FunctionAlpha()
    {
        if(Input.GetKey(KeyCode.E))
            hitBox.SetActive(true);

        base.FunctionAlpha();
    }

   

}
