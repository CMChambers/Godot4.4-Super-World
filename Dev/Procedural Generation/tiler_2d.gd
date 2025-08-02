extends Node3D
class_name Tiler2D

@export var object_to_tile : PackedScene
@export var tile_size_width : float = 1.0
@export var tile_size_depth : float = 1.0
@export var center : Node3D
@export var view_range_start : int = 0
@export var view_range_stop : int = 1

var chunks = {}
var unready_chunks = {}
var thread : Thread


var tile_dictionary : Dictionary

func _ready() -> void:
	thread = Thread.new()
	
func add_chunk(x, z):
	var key = str(x) + "," + str(z)
	if chunks.has(key) or unready_chunks.has(key):
		return
	
	if not thread.is_alive():
		# thread.start(self, "load_chunk", [thread, x, z])
		unready_chunks[key] = 1

# func load_chunk(arr):
# 	var thread = arr[0]
# 	var x = arr[1]
# 	var z = arr[2]
	
# 	var chunk #= Chunk.new(noise, x, z, chunk_size)
	
	
	
# func _physics_process(delta: float) -> void:
# 	pass
# 	#get_player_location()
# 	#check_active_center_tile()
# 	#enable_tiles_in_range()
# 	#disable_tiles_out_of_range()
