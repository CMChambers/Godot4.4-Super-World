extends Player

@export_category("Look")
@onready var Camera_Pivot: Node3D = $"Camera Pivot"
var input_look_mouse := Vector2.ZERO
var input_look_joystick := Vector2.ZERO
var input_look := Vector2.ZERO
@export var Mouse_Look_Speed: float = 10.0
var Mouse_Look_Speed_Divisor: float = 10000
@export var Joystick_Look_Speed := 1.0
var Joystick_Look_Speed_Divisor := 100

@export_category("Move")
@export var Speed: float = 5.0

@export_category("Jump")
@export var Jump_Gravity: float = ProjectSettings.get_setting("physics/3d/default_gravity")
@export var Fall_Gravity: float = 5.0
@export var Jump_Peak_Time: float = 0.5
@export var Jump_Fall_Time: float = 0.5
@export var Jump_Height: float = 2.0
@export var Jump_Distance: float = 4.0
@export var Jump_Velocity: float = 5.0
@export var Coyote_Time: float = 0.3
var Jump_Available := true
@onready var coyote_timer: Timer = $CoyoteTimer
var Jump_Buffer : bool = false
@export var Jump_Buffer_Time : float = 1.0

func _input(event: InputEvent) -> void:
	if event is InputEventMouseMotion:
		if Input.mouse_mode == Input.MOUSE_MODE_CAPTURED:
			input_look_mouse = -event.relative * (Mouse_Look_Speed / Mouse_Look_Speed_Divisor)
	if event.is_action_pressed("ui_cancel"):
		Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
	if event is InputEventJoypadMotion:
		input_look_joystick = Input.get_vector("LookRight", "LookLeft", "LookUp", "LookDown") * (Joystick_Look_Speed / Joystick_Look_Speed_Divisor)


func Calculate_Movement_Parameters() -> void:
	Jump_Gravity = (2 * Jump_Height) / pow(Jump_Peak_Time, 2)
	Fall_Gravity = (2 * Jump_Height) / pow(Jump_Fall_Time, 2)
	Jump_Velocity = Jump_Gravity * Jump_Peak_Time

func _ready() -> void:
	Calculate_Movement_Parameters()
	Input.mouse_mode = Input.MOUSE_MODE_CAPTURED
	
func _physics_process(delta: float) -> void:
	handle_camera_rotation()
		
	# Add the gravity.
	if not is_on_floor():
		if Jump_Available:
			if coyote_timer.is_stopped():
				coyote_timer.start(Coyote_Time)
		else:
			if velocity.y > 0:
				velocity.y -= Jump_Gravity * delta
			else:
				velocity.y -= Fall_Gravity * delta
	else:
		Jump_Available = true
		coyote_timer.stop()
		if Jump_Buffer:
			Jump()
			Jump_Buffer = false

	# Handle jump.
	#if Input.is_action_just_pressed("Jump") and Jump_Available:
		#velocity.y = Jump_Velocity
		#Jump_Available = false
	if Input.is_action_just_pressed("Jump"):
		if Jump_Available:
			Jump()
		else:
			Jump_Buffer = true
			get_tree().create_timer(Jump_Buffer_Time).timeout.connect(on_jump_buffer_timeout)

	# Get the input direction and handle the movement/deceleration.
	var input_dir := Input.get_vector("Left", "Right", "Forward", "Back")
	var direction := (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	if direction:
		velocity.x = direction.x * Speed
		velocity.z = direction.z * Speed
	else:
		velocity.x = move_toward(velocity.x, 0, Speed)
		velocity.z = move_toward(velocity.z, 0, Speed)

	move_and_slide()

func Jump() -> void:
		velocity.y = Jump_Velocity
		Jump_Available = false

func Coyote_Timeout():
	Jump_Available = false
	
func on_jump_buffer_timeout() -> void:
	Jump_Buffer = false

func handle_camera_rotation() -> void:
	input_look = input_look_joystick + input_look_mouse
	
	printt(input_look_mouse, input_look_joystick, input_look)
	
	rotate_y(input_look.x)
	Camera_Pivot.rotate_x(input_look.y)
	Camera_Pivot.rotation_degrees.x = clampf(Camera_Pivot.rotation_degrees.x, -90.0, 90.0)
	
	#input_look_joystick = Vector2.ZERO
	input_look_mouse = Vector2.ZERO
	input_look = Vector2.ZERO
