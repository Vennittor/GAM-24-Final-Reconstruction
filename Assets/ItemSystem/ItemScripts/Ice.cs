
using UnityEngine;

public class Ice : ItemBaseScript 
{
        bool canFreeze = false;

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
        public override void FunctionBeta()
        {
            //make them prone
            durability--;
            base.FunctionBeta();
        }
        void OnCollisionEnter(Collision other)
        {
            if (thrown)
            {
            FunctionBeta();
            }
        }
    }
