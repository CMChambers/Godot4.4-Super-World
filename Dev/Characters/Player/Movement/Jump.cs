using Godot;

namespace CMC.Superworld.Characters
{
	[Tool]
	[GlobalClass]
	public partial class Jump : MovementType
	{
		[Export] public float jumpHeight = 2f;
		[Export] public float jumpSpeed = 5f;

		public override bool IsActive(InputState inputState, CharacterBody3D body)
		{
			return true;
		}
		public override Vector3 AddMovement(InputState inputState, MovementController movementController, double delta)
		{
			return Vector3.Zero;
		}

	}
}