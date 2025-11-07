using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovement
{
    public class PlayerMovementState : IState
    {
        public virtual void Enter()
        {
            Debug.Log("State: " + GetType().Name);  //this will show the current class name
        }

        public virtual void Exit()
        {

        }

        public virtual void HandleInput()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Update()
        {

        }
    }
}
