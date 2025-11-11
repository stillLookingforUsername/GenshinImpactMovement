using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovement
{
    public class PlayerMovementStateMachine : StateMachine
    {
        public Player Player { get; }
        public PlayerIdlingState IdlingState { get; private set; }
        public PlayerWalkingState WalkingState { get; private set; }
        public PlayerRunningState RunningState { get; private set; }
        public PlayerSprintingState SprintingState { get; private set; }

        public PlayerMovementStateMachine(Player player)
        {
            Player = player;
            IdlingState = new PlayerIdlingState(this);
            WalkingState = new PlayerWalkingState(this);
            RunningState = new PlayerRunningState(this);
            SprintingState = new PlayerSprintingState(this);
        }
    }
}
