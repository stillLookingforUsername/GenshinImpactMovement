using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovement
{
    public class PlayerMovementStateMachine : StateMachine
    {
        public PlayerIdlingState IdlingState { get; private set; }
        public PlayerWalkingState WalkingState { get; private set; }
        public PlayerRunningState RunningState { get; private set; }
        public PlayerSprintingState SprintingState { get; private set; }

        public PlayerMovementStateMachine()
        {
            IdlingState = new PlayerIdlingState();
            WalkingState = new PlayerWalkingState();
            RunningState = new PlayerRunningState();
            SprintingState = new PlayerSprintingState();
        }
    }
}
