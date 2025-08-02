using Godot;

namespace CMC.Superworld.Characters
{
	// [Tool]
	[GlobalClass]
	public partial class MovementController : CharacterBody3D
	{
		[Export] public PlayerInputHandler playerInputHandler; // assign in inspector
		[Export] public Node3D cameraRotation;
		[Export] public Node3D cameraPivot;

		[Export] public LookController look;

		[Export] public SlideMethod slideMethod;
		[Export] public MovementType[] arcadeMovementTypes;
		[Export] public MovementType[] physicsMovementTypes;
		public SlideMethod SlideMethod = SlideMethod.ArcadeLike;
		// [Export] public Node InputProviderNode; // assign in inspector


		public override void _PhysicsProcess(double delta)
		{
			base._PhysicsProcess(delta);

			GD.Print("in PhysicsProcess");
			if (playerInputHandler == null) { GD.PrintErr("input handler is null"); return; }
			InputState inputState = playerInputHandler.GetInput();
			GD.Print("in PhysicsProcess after GetInput");


			ApplyLook(inputState);
			AddUpMovement(delta, inputState);
			GD.Print("in PhysicsProcess after AddUpMovement");


			MoveAndSlide();


			void ApplyLook(InputState inputState)
			{
				GD.Print("in ApplyLook");
				if (look.IsActive(inputState, this))
				{
					look.ApplyLook(inputState, cameraRotation, cameraPivot, delta);
				}
			}

			void AddUpMovement(double delta, InputState inputState)
			{
				GD.Print("in AddUpMovement");

				MovementType[] activeMovementTypes = (SlideMethod == SlideMethod.ArcadeLike) ? arcadeMovementTypes : physicsMovementTypes;

				Vector3 totalMovement = Vector3.Zero;
				foreach (MovementType type in activeMovementTypes)
				{
					GD.Print($"for each type in activeMovementTypes: {type}");
					if (type.IsActive(inputState, this))
					{
						if (type.IsOverride) { GD.Print("type is override"); return; }
						// GD.Print("type is active");
						totalMovement += type.AddMovement(inputState, this, delta);
					}
				}

				Velocity += totalMovement;
				// GD.Print($"velocity: {Velocity}");
			}
		}
	}
	public enum SlideMethod { ArcadeLike, PhysicsLike }
}