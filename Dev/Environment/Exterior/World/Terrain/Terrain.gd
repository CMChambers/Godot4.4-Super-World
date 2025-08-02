extends Node3D
class_name Terrain

var mesh : MeshInstance3D
@export var size_depth : int = 100
@export var size_width : int = 100
@export var mesh_resolution : int = 2

@export var value_grid_2d: ValueGrid2D

@export var ground_material = preload("res://Dev/Surfaces/Materials/basic_ground_material.tres")


func _ready():
	generate()
	
func generate():
	var plane_mesh = PlaneMesh.new()
	plane_mesh.size = Vector2(size_width, size_depth)
	plane_mesh.subdivide_depth = size_depth * mesh_resolution
	plane_mesh.subdivide_width = size_width * mesh_resolution
	plane_mesh.material = ground_material
	
	var surface = SurfaceTool.new()
	var data = MeshDataTool.new()
	surface.create_from(plane_mesh, 0)
	
	var array_plane = surface.commit()
	data.create_from_surface(array_plane, 0)
	
	for i in range(data.get_vertex_count()):
		var vertex = data.get_vertex(i)
		vertex.y = value_grid_2d.evaluate(vertex.x, vertex.z)
		#vertex.y = get_noise_y(vertex.x, vertex.z)
		data.set_vertex(i, vertex)
		
	array_plane.clear_surfaces()
	data.commit_to_surface(array_plane)
	surface.begin(Mesh.PRIMITIVE_TRIANGLES)
	surface.create_from(array_plane, 0)
	surface.generate_normals()
	
	
	mesh = MeshInstance3D.new()
	mesh.mesh = surface.commit()
	mesh.create_trimesh_collision()
	mesh.cast_shadow = GeometryInstance3D.SHADOW_CASTING_SETTING_OFF
	
	#adds mesh to group for generating navmesh
	mesh.add_to_group("NavSource")
	
	add_child(mesh)

