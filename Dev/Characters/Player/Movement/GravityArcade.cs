using Godot;

namespace CMC.Superworld.Characters
{
	[Tool]
	[GlobalClass]
	public partial class GravityArcade : MovementType
	{
		[Export] public float fallSpeed = 9.8f;


		public override bool IsActive(InputState inputState, CharacterBody3D body)
		{
			if (body.IsOnFloor()) { return false; }
			return true;
		}

		public override Vector3 AddMovement(InputState inputState, MovementController movementController, double delta)
		{
			GD.Print($"in gravity (arcade)");
			Vector3 direction = new Vector3(0, -1, 0);
			return direction * fallSpeed * (float)delta;
		}

	}
}