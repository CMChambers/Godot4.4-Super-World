using Godot;
using System;

public partial class Better_Jump_Player : Player
{
	[ExportCategory("Move")]
	[Export(PropertyHint.Range, "0,10,")] private float Speed = 5.0f;

	[ExportCategory("Jump")]
	[Export(PropertyHint.Range, "0,1,")] private float Jump_Peak_Time = .5f;
	[Export(PropertyHint.Range, "0,1,")] private float Jump_Fall_Time = .5f;
	[Export(PropertyHint.Range, "0,10,")] private float Jump_Height = 2f;
	[Export(PropertyHint.Range, "0,10,")] private float Jump_Distance = 4f;
	[Export] private float JumpVelocity = 4.5f;
	[Export] private bool Jump_Available = true;
	[Export(PropertyHint.Range, "0,1,")] private float Coyote_Time = .5f;

	[ExportCategory("Gravity")]
	[Export] private float Jump_Gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	[Export] private float Fall_Gravity = 5f;

	void Calculate_Movement_Parameters()
	{
		Jump_Gravity = (2 * Jump_Height) / Mathf.Pow(Jump_Peak_Time, 2);
		Fall_Gravity = (2 * Jump_Height) / Mathf.Pow(Jump_Fall_Time, 2);
		JumpVelocity = Jump_Gravity * Jump_Peak_Time;
	}
	public override void _Ready()
	{
		Calculate_Movement_Parameters();
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			// Timer timer = GetTree().CreateTimer(Coyote_Time);
			// timer.Connect("timeout", this, Coyote_Timeout);
			if (velocity.Y > 0)
			{
				velocity.Y -= Jump_Gravity * (float)delta;
			}
			else
			{
				velocity.Y -= Fall_Gravity * (float)delta;
			}
		}
		else
		{
			Jump_Available = true;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && Jump_Available)
		{
			velocity.Y = JumpVelocity;
			Jump_Available = false;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	void Coyote_Timeout()
	{
		Jump_Available = false;
	}
}
