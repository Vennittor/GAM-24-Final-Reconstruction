
using UnityEngine;

public class Ice : ItemBaseScript 
{
        bool canFreeze = false;
    float length = 5; 
        // Use this for initialization
        public override void Start()
        {
            durability = 1;
            base.Start();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
        {
            Released(throwDirection);
            base.FunctionAlpha(throwDirection);
        }
        public void FunctionBeta(GameObject player)
        {
            player.GetComponent<BaseCharacter>().Freeze(length);
            durability--;
            base.FunctionBeta();
        }
        void OnCollisionEnter(Collision other)
        {
             if (thrown)
             {
                if (other.gameObject.GetComponent<BaseCharacter>())
                {
                    FunctionBeta(other.gameObject);
                }
                else
                    durability--;
             }
        }
    }
