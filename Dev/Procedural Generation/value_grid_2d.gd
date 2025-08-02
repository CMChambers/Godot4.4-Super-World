extends Resource
class_name ValueGrid2D

@export var layers: Array[ValueLayer] = []

func evaluate(x: int, y: int) -> float:
	var final_value := 0.0
	for item in layers:
		final_value += item.evaluate(x, y)
	return final_value
