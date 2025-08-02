using Godot;

namespace CMC.Superworld.Characters
{
	[Tool]
	[GlobalClass]
	public partial class LookController : Resource
	{
		public bool IsActive(InputState inputState, MovementController body)
		{
			return true;
		}

		public void ApplyLook(InputState input, Node3D CameraRotation, Node3D CameraTilt, double delta)
		{

			GD.Print($"in look module: {CameraRotation.RotationDegrees}, {CameraTilt.RotationDegrees}");

			// Horizontal: Y-axis rotation of the character (cameraRotation)
			CameraRotation.RotateY(-input.Look.X);

			// Vertical: X-axis rotation of the camera pivot (pitch)
			float pitchChange = -input.Look.Y;
			Vector3 currentRotation = CameraTilt.Rotation;

			// Clamp pitch (e.g., -90 to 90 degrees)
			float newPitch = Mathf.Clamp(currentRotation.X + pitchChange, Mathf.DegToRad(-90), Mathf.DegToRad(90));
			CameraTilt.Rotation = new Vector3(newPitch, currentRotation.Y, currentRotation.Z);
		}
	}
}