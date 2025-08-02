extends Resource
class_name ValueLayer

enum ValueSource {random, noise, texture}
enum ValueRange {zero_to_one, negative_one_to_one}

@export_group("Layer Properties")
@export var enabled := true
#@export var name : String
@export var clipping_mask := false
@export_range(0.0, 100.0) var gain : float = 1.0
@export_range(-100, 100) var y_offset : float = 0.0

#@export var fast_noise_lite : FastNoiseLite
@export var value_source: ValueSource
@export var random_textrue: RandomTexture2D
@export var image_texture: ImageTexture
@export var noise_texture: NoiseTexture2D
@export var value_range: ValueRange

@export var octaves : int = 1
@export_range(0.1, 10) var frequency := 1.0
@export_range(0, 1) var amplitude := 1.0
@export var height_curve : Curve
@export var offset : Vector2
@export var offset_move_speed : Vector2

func evaluate(x: int, z: int) -> float:

	match value_source:
		ValueSource.random:
			return Evaluate_Random(x, z)
		ValueSource.noise:
			return Evaluate_Noise(x, z)
		ValueSource.texture:
			return Evaluate_Texture(x, z)
	return 0.0

func Evaluate_Random(x: int, z: int) -> float:
	return 1.0
func Evaluate_Texture(x: int, z: int) -> float:
	return 1.0
	
func Evaluate_Noise(x: int, z: int) -> float:
	var value: float
	match value_range:
		ValueRange.zero_to_one:
			value = (noise_texture.noise.get_noise_2d(x, z) + 1) * 0.5
		ValueRange.negative_one_to_one:
			value = noise_texture.noise.get_noise_2d(x, z)

	
		
	value *= amplitude
	
	value *= gain
	value += y_offset
	
	return value
