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
var input_dir : Vector2
@export var max_speed: float = 5.0
@export_range(0.001, 2.0) var friction: float = 2.0
@export var in_air_control : bool = true

@export_category("Jump")
@export var Jump_Gravity: float = ProjectSettings.get_setting("physics/3d/default_gravity")
@export var Fall_Gravity: float = 5.0
@export var Jump_Peak_Time: float = 0.5
@export var Jump_Fall_Time: float = 0.5
@export var Jump_Height: float = 2.0
@export var Jump_Distance: float = 4.0
@export var Jump_Velocity: float = 5.0
@export var Use_Coyote_Time := true
@export var Coyote_Time_Rabbit_Time := true
@export var Coyote_Time_Duration: float = 0.3
var Jump_Available := true
@onready var coyote_timer: Timer = $CoyoteTimer
@export var Use_Jump_Buffer := true
var Jump_Buffer : bool = false
@export var Jump_Buffer_Time : float = 1.0

func _input(event: InputEvent) -> void:
	input_dir = Input.get_vector("Left", "Right", "Forward", "Back")
	if event is InputEventMouseMotion:
		if Input.mouse_mode == Input.MOUSE_MODE_CAPTURED:
			input_look_mouse = -event.relative * (Mouse_Look_Speed / Mouse_Look_Speed_Divisor)
	if event.is_action_pressed("ui_cancel"):
		Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
	if event is InputEventJoypadMotion:
		input_look_joystick = Input.get_vector("LookRight", "LookLeft", "LookUp", "LookDown") * (Joystick_Look_Speed / Joystick_Look_Speed_Divisor)

func _ready() -> void:
	Calculate_Movement_Parameters()
	Input.mouse_mode = Input.MOUSE_MODE_CAPTURED

func Calculate_Movement_Parameters() -> void:
	if friction > 1:
		friction = (friction - 1) * max_speed
	Jump_Gravity = (2 * Jump_Height) / pow(Jump_Peak_Time, 2)
	Fall_Gravity = (2 * Jump_Height) / pow(Jump_Fall_Time, 2)
	Jump_Velocity = Jump_Gravity * Jump_Peak_Time
	
func _physics_process(delta: float) -> void:
	handle_look()
	handle_gravity(delta)
	handle_jump()
	handle_movement()
	#if velocity.length() > 0:		#print(velocity.length())
	move_and_slide()

func handle_movement() -> void:
	#printt(not in_air_control, not is_on_floor(), not in_air_control and not is_on_floor(), (not in_air_control) and (not is_on_floor()))
	if (not in_air_control) and (not is_on_floor()):
		return
	#if in_air_control and not is_on_floor():
		
	var direction := (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	if direction:
		velocity.x = move_toward(velocity.x, direction.x*max_speed, max_speed*friction)
		velocity.z = move_toward(velocity.z, direction.z*max_speed, max_speed*friction)
	else:
		velocity.x = move_toward(velocity.x, 0, max_speed*friction)
		velocity.z = move_toward(velocity.z, 0, max_speed*friction)

func handle_jump() -> void:
	if Input.is_action_just_pressed("Jump"):
		if Jump_Available:
			ExecuteJump()
		else:
			Jump_Buffer = true
			get_tree().create_timer(Jump_Buffer_Time).timeout.connect(on_jump_buffer_timeout)
	
func ExecuteJump() -> void:
		velocity.y = Jump_Velocity
		Jump_Available = false

func handle_gravity(delta: float) -> void:
	if is_on_floor():
		Jump_Available = true
		coyote_timer.stop()
		if Jump_Buffer:
			ExecuteJump()
			Jump_Buffer = false
	else:
		if Jump_Available:
			if coyote_timer.is_stopped():
				coyote_timer.start(Coyote_Time_Duration)
		else:
			if velocity.y > 0:
				velocity.y -= Jump_Gravity * delta
			else:
				velocity.y -= Fall_Gravity * delta


func Coyote_Timeout():
	Jump_Available = false
	
func on_jump_buffer_timeout() -> void:
	Jump_Buffer = false

func handle_look() -> void:
	input_look = input_look_joystick + input_look_mouse
	rotate_y(input_look.x)
	Camera_Pivot.rotate_x(input_look.y)
	Camera_Pivot.rotation_degrees.x = clampf(Camera_Pivot.rotation_degrees.x, -90.0, 90.0)
	#input_look_joystick = Vector2.ZERO
	input_look_mouse = Vector2.ZERO
	input_look = Vector2.ZERO
	#printt(input_look_mouse, input_look_joystick, input_look)
