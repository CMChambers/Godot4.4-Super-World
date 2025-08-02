using Godot;
using System;

[Tool]
[GlobalClass]
public partial class GroundGeneratorSettings : Resource
{
   [ExportGroup("Ground Properties")]
   [Export] public Vector2 location;
   [Export] public Vector2 offset;
   [Export] public Vector2 size;
   [Export] public Vector2 subdivisions;

   [ExportGroup("Noise Layers")]
   [Export] public NoiseLayerManager noiseLayerManager;

}
