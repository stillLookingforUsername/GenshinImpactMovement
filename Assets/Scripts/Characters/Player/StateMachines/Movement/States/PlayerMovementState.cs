using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace GenshinImpactMovement
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;
        protected Vector2 movementInput;
        protected float baseSpeed = 5f; // Base movement speed
        protected float speedModifier = 1f; // This can be modified by walk/run toggle or other effects
        public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine; 
        }
        #region IState Implementation
        public virtual void Enter()
        {
            Debug.Log("State: " + GetType().Name);  //this will show the current class name
        }

        public virtual void Exit()
        {

        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }

        public virtual void PhysicsUpdate()
        {
            Move();
        }

        public virtual void Update()
        {

        }
        #endregion

        #region Main Input Reading
        private void ReadMovementInput()
        {
            movementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }
        private void Move()
        {
            if (movementInput == Vector2.zero || speedModifier == 0f) return;
            Vector3 movementDirection = GetMovementInputDirection();
            float movementSpeed = GetMovementSpeed();
            Vector3 currentPlayerHorizontalVeclocity = GetPlayerHorizontalVelocity();
            stateMachine.Player.Rigidbody.AddForce(movementDirection * movementSpeed - currentPlayerHorizontalVeclocity, ForceMode.VelocityChange);
        }
        #endregion

        #region Resuable Methods
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y); 
        }
        protected float GetMovementSpeed()
        {
            return baseSpeed * speedModifier;
        }
        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;
            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }
        #endregion
    }
}
