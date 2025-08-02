using Godot;

namespace CMC.Superworld.Characters
{
	[Tool]
	[GlobalClass]
	public abstract partial class MovementType : Resource
	{
		public bool IsOverride = false;
		public abstract bool IsActive(InputState inputState, CharacterBody3D body); // FSM logic
		public abstract Vector3 AddMovement(InputState inputState, MovementController movementController, double delta);

		// void PhysicsProcess(float delta, InputState input, CharacterBody3D body)
		// { }

	}
}
