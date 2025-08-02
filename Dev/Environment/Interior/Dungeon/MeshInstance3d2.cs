
using Godot;
using System;

public partial class MeshInstance3d2 : MeshInstance3D
{
	private Vector3 _startPosition;
	private Vector3 _targetPosition;
	private float _duration = 2f; // seconds
	private float _timer = 0f;
	private bool _movingForward = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_startPosition = GlobalPosition;
		_targetPosition = _startPosition + new Vector3(10, 0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_timer += (float)delta;
		float t = Mathf.Clamp(_timer / _duration, 0f, 1f);
		if (_movingForward)
			GlobalPosition = _startPosition.Lerp(_targetPosition, t);
		else
			GlobalPosition = _targetPosition.Lerp(_startPosition, t);

		if (_timer >= _duration)
		{
			_timer = 0f;
			_movingForward = !_movingForward;
		}
	}
}
