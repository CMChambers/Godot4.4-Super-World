extends Node3D

var time : float
var time_rate : float
@export var day_length : float = 20.0
@export var start_time : float = 0.3
@export_range(0, 360, 45) var start_angle : int = 90

@onready var sun_light: DirectionalLight3D = $SunLight
@export var sun_color : Gradient
@export var sun_intensity : Curve

func _ready() -> void:
	time_rate = 1.0 / day_length
	time  = start_time
	
func _process(delta: float) -> void:
	time += time_rate * delta
	if time >= 1.0:
		time = 0.0
	sun_light.rotation_degrees.x = time * 360 + start_angle
	sun_light.light_color = sun_color.sample(time)
	sun_light.light_energy = sun_intensity.sample(time)
	
