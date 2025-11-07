Step-1	IState - State Interface (methods that a state machine must need to implement).
				- Enter() : Runs whenever a state becomes the current state. 
				- Exit()  : Runs whenever a State becomes the Previous State.
				- HandleInput()
				- Update()
				- PhysicsUpdate()


Step-2	StateMachine - Base State Machine(using Abstract class) & this is the class that every StateMachine we create will inherit from. This stateMachine will take care of all of the
						Player Movement States.
				- protected IState currentState :variable that will hold the current State
				- public void ChangeState(IState newState)
				- public void HandleInput()
				- public void Update()
				- public void PhysicsUpdate()
				
Step-3 PlayerMovementStateMachine  - **(know about Caching VS Instantiating STATES)
				
