extends MeshInstance3D

var start_position: Vector3
var target_position: Vector3
var duration: float = 2.0
var timer: float = 0.0
var moving_forward: bool = true

func _ready() -> void:
	start_position = global_position
	target_position = start_position + Vector3(10, 0, 0)

func _process(delta: float) -> void:
	timer += delta
	var t: float = clamp(timer / duration, 0.0, 1.0)

	if moving_forward:
		global_position = start_position.lerp(target_position, t)
	else:
		global_position = target_position.lerp(start_position, t)

	if timer >= duration:
		timer = 0.0
		moving_forward = not moving_forward
