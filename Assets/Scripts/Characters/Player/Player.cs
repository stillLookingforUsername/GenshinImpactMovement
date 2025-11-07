using UnityEngine;

namespace GenshinImpactMovement
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        public PlayerInput Input{ get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        private PlayerMovementStateMachine movementStateMachine;
        //private SkinnedMeshRenderer meshRendererSize;
        private void Awake()
        {
            movementStateMachine = new PlayerMovementStateMachine();
            Input = GetComponent<PlayerInput>();
            Rigidbody = GetComponent<Rigidbody>();
            //meshRendererSize = GetComponentInChildren<SkinnedMeshRenderer>();
        }
        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
            //Debug.Log("Player Mesh Size: " + meshRendererSize.bounds.size);
        }
        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }
        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }

    }
}
